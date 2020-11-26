using Microsoft.Extensions.DependencyInjection;
using Reguto.Test.FakeObjects;
using System.Reflection;
using Xunit;

namespace Reguto.Test
{
    public class DependencyRegistrarTest
    {
        private readonly IServiceCollection services = new ServiceCollection();
        private readonly Assembly assembly;

        public DependencyRegistrarTest()
        {
            assembly = GetType().Assembly;
        }

        [Fact]
        public void Test_Services()
        {
            services.ScanAndRegister(assembly);

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<IService>();
            var serviceType = service.GetType();

            Assert.Equal(typeof(Service), serviceType);
        }

        [Fact]
        public void Test_Factories()
        {
            services.ScanAndRegister(assembly);

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<IFactory>();
            var serviceType = service.GetType();

            Assert.Equal(typeof(Factory), serviceType);
        }

        [Fact]
        public void Test_Injectables()
        {
            services.ScanAndRegister(assembly);

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<IInjectable>();
            var serviceType = service.GetType();

            Assert.Equal(typeof(Injectable), serviceType);
        }

        [Fact]
        public void Test_AsSelf()
        {
            services.ScanAndRegister(assembly);

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<SelfService>();
            var serviceType = service.GetType();

            Assert.Equal(typeof(SelfService), serviceType);
        }

        [Fact]
        public void Test_Singleton_Lifetime()
        {
            services.ScanAndRegister(assembly);

            var serviceProvider = services.BuildServiceProvider();

            var service1 = serviceProvider.GetService<IFactory>();
            var service2 = serviceProvider.GetService<IFactory>();

            Assert.Equal(service1, service2);
        }

        [Fact]
        public void Test_Scoped_Lifetime()
        {
            services.ScanAndRegister(assembly);

            var serviceProvider = services.BuildServiceProvider();

            var scope1 = serviceProvider.CreateScope();
            var service1 = scope1.ServiceProvider.GetService<IService>();
            var service2 = scope1.ServiceProvider.GetService<IService>();

            Assert.Equal(service1, service2);

            var scope2 = serviceProvider.CreateScope();
            var service3 = scope2.ServiceProvider.GetService<IService>();

            Assert.NotEqual(service3, service2);
            Assert.NotEqual(service3, service1);
        }

        [Fact]
        public void Test_Transient_Lifetime()
        {
            services.ScanAndRegister(assembly);

            var serviceProvider = services.BuildServiceProvider();

            var service1 = serviceProvider.GetService<IInjectable>();
            var service2 = serviceProvider.GetService<IInjectable>();

            Assert.NotEqual(service1, service2);
        }
    }
}
