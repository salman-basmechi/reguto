using Microsoft.Extensions.DependencyInjection;
using Reguto.Annotations;
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
    }

    public interface IService { }

    [Service]
    public class Service : IService { }

    public interface IFactory { }

    [Factory]
    public class Factory : IFactory { }
}
