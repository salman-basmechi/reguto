using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Reguto.DI.Abstractions;

namespace Reguto.DI.Microsoft
{
    /// <summary>
    /// Scan and register all dependencies.
    /// </summary>
    public static class DependencyRegistrar
    {
        /// <summary>
        /// Scan app domain assemblies and register all dependencies that have any reguto attributes.
        /// </summary>
        /// <param name="services"></param>
        public static void ScanAndRegister(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.ScanAndRegister(assemblies);
        }

        /// <summary>
        /// Scan entry assemblies and register all dependencies that have any reguto attributes.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assemblies"></param>
        public static void ScanAndRegister(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.ScanAndRegister(assemblies, InjectionMode.Singleton, true);
            services.ScanAndRegister(assemblies, InjectionMode.Scoped, true);
            services.ScanAndRegister(assemblies, InjectionMode.Transient, true);
            services.ScanAndRegister(assemblies, InjectionMode.Singleton, false);
            services.ScanAndRegister(assemblies, InjectionMode.Scoped, false);
            services.ScanAndRegister(assemblies, InjectionMode.Transient, false);
        }

        private static void ScanAndRegister(this IServiceCollection services,
                                            Assembly[] assemblies,
                                            InjectionMode injectionMode,
                                            bool asSelf)
        {
            services.Scan(scan =>
            {
                var serviceTypeSelector = scan.FromAssemblies(assemblies)
                                              .AddClasses(classes => classes.Where(type =>
                                              {
                                                  var injectionAttributeType = typeof(InjectableAttribute);
                                                  var customAttribute = type.GetCustomAttributes()
                                                                             .FirstOrDefault(attribute =>
                                                                             {
                                                                                 var attributeType = attribute.GetType();

                                                                                 return attributeType == injectionAttributeType ||
                                                                                        attributeType.IsSubclassOf(injectionAttributeType);
                                                                             });

                                                  if (customAttribute is null)
                                                  {
                                                      return false;
                                                  }

                                                  var injectableAttribute = (InjectableAttribute)customAttribute;

                                                  return injectableAttribute.AsSelf == asSelf &&
                                                         injectableAttribute.Mode == injectionMode;
                                              }));

                var lifeTimeSelector = asSelf ? serviceTypeSelector.AsSelf() : serviceTypeSelector.AsImplementedInterfaces();
                switch (injectionMode)
                {
                    case InjectionMode.Singleton:
                        {
                            lifeTimeSelector.WithSingletonLifetime();
                            break;
                        }
                    case InjectionMode.Scoped:
                        {
                            lifeTimeSelector.WithScopedLifetime();
                            break;
                        }
                    case InjectionMode.Transient:
                        {
                            lifeTimeSelector.WithTransientLifetime();
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException(nameof(injectionMode), injectionMode, null);
                }
            });
        }
    }
}
