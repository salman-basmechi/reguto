#Reguto
Scan and register all dependencies and options based on attribute.

You can get the latest stable release from the [nuget.org](http://www.nuget.org/packages/reguto) or from [github releases page](https://github.com/salmanbasmechi/reguto/releases).

```C#
    public interface IIdentityService
    {
        Task<AuthenticationResponse> AuthenticateAsync(string username, string password);
    }
```

Annotate service class as scoped dependency with ServiceAttribute
```C#
    [Service]
    public class IdentityService : IIdentityService
    {
        private readonly IOptions<JwtOptions> options;

        public IdentityService(IOptions<JwtOptions> options)
        {
            this.options = options ?? throw new System.ArgumentNullException(nameof(options));
        }

        public Task<AuthenticationResponse> AuthenticateAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
```

Annotate options class and determine value section in appSettings.json or other settings file.
```C#
    [Options("Jwt")]
    public class JwtOptions
    {
        public string Secret { get; init; }

        public string ExpiryMinutes { get; init; }
    }
```

Register all dependencies and options in startup.
```C#
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reguto;

namespace Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ScanAndRegister();
            services.ScanAndConfigureOptions(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // configure
        }
    }
}
```
