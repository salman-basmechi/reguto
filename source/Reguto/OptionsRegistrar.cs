using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reguto.Annotations;
using System;
using System.Linq;
using System.Reflection;

namespace Reguto
{
    public static class OptionsRegistrar
    {
        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.ConfigureOptions(configuration, assemblies);
        }

        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var options = from type in assembly.GetTypes()
                              let optionAttribute = type.GetCustomAttributes()
                                                        .FirstOrDefault(c => c.GetType() == typeof(OptionsAttribute))
                              where optionAttribute != null
                              select new
                              {
                                  Type = type,
                                  ((OptionsAttribute)optionAttribute).Section
                              };

                foreach (var option in options)
                {
                    var section = configuration.GetSection(option.Section);
                    var extensionType = typeof(OptionsConfigurationServiceCollectionExtensions);
                    string methodName = nameof(OptionsConfigurationServiceCollectionExtensions.Configure);

                    extensionType.GetMethods()
                                 .Where(c => c.Name == methodName)
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
    }
}
