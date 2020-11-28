using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Reguto.Test.FakeObjects;
using System.Reflection;
using Xunit;

namespace Reguto.Test
{
    public class OptionsRegistrarTest
    {
        private readonly IServiceCollection services = new ServiceCollection();
        private readonly IConfiguration configuration;
        private readonly Assembly assembly;

        public OptionsRegistrarTest()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json")
                                                      .Build();

            assembly = GetType().Assembly;
        }

        [Fact]
        public void Test_Options_Registration()
        {
            var options = GetFakeOptions();

            Assert.NotNull(options);
        }

        private IOptions<FakeOptions> GetFakeOptions()
        {
            services.ScanAndConfigureOptions(configuration, assembly);

            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider.GetService<IOptions<FakeOptions>>();
        }
    }
}
