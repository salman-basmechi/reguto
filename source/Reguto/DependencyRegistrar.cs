using Microsoft.Extensions.DependencyInjection;
using Reguto.Annotations;
using System;
using System.Linq;
using System.Reflection;

namespace Reguto
{
    public static class DependencyRegistrar
    {
        public static void ScanAndRegister(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            services.ScanAndRegister(assemblies);
        }

        public static void ScanAndRegister(this IServiceCollection services, params Assembly[] assemblies)
        {
            if(assemblies is null)
            {
                return;
            }

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
                                                  var customeAttribute = type.GetCustomAttributes()
                                                                             .FirstOrDefault(c => c.GetType().IsSubclassOf(injectionAttributeType));

                                                  if (customeAttribute is null)
                                                  {
                                                      return false;
                                                  }

                                                  var injectableAttribute = (InjectableAttribute)customeAttribute;

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
                }
            });
        }
    }
}
