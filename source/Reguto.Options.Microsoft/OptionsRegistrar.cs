using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reguto.Options.Abstractions;

namespace Reguto.Options.Microsoft
{
    /// <summary>
    /// Scan and register all options.
    /// </summary>
    public static class OptionsRegistrar
    {
        /// <summary>
        /// Scan app domain assemblies and register all options.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ScanAndConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.ScanAndConfigureOptions(configuration, assemblies);
        }

        /// <summary>
        /// Scan entry assemblies and register all options.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="assemblies"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void ScanAndConfigureOptions(this IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
        {
            var options = from assembly in assemblies
                          from option in assembly.FindOptions()
                          select option;

            foreach (var option in options)
            {
                services.ConfigureOption(configuration, option);
            }
        }

        private static IEnumerable<(Type Type, string Section)> FindOptions(this Assembly assembly)
        {
            var options = from type in assembly.GetTypes()
                          let optionsAttribute = (OptionsAttribute?)type.GetCustomAttributes()
                                                                      .FirstOrDefault(c => c.GetType() == typeof(OptionsAttribute))
                          where optionsAttribute is not null
                          select (type, optionsAttribute.Section);

            return options;
        }

        private static void ConfigureOption(this IEnumerable services, IConfiguration configuration, (Type Type, string Section) option)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var section = configuration.GetSection(option.Section);
            var extensionType = typeof(OptionsConfigurationServiceCollectionExtensions);
            const string MethodName = nameof(OptionsConfigurationServiceCollectionExtensions.Configure);

            extensionType.GetMethods()
                         .Where(c => c.Name == MethodName)
                         .First(c =>
                         {
                             var parameters = c.GetParameters()
                                               .ToArray();

                             return parameters.Length == 2 &&
                                    parameters[0].ParameterType == typeof(IServiceCollection) &&
                                    parameters[1].ParameterType == typeof(IConfiguration);
                         })
                         .MakeGenericMethod(option.Type)
                         .Invoke(null, new object[] { services, section });
        }
    }
}
