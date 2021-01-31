using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApi.Constants;
using WebApi.Contracts;
using WebApi.Infrastructure.Handlers;
using WebApi.Services;

namespace WebApi.Infrastructure.Installers
{
    internal class RegisterApiResources : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration config)
        {

            //Register custom Bearer Token Handler. The DelegatingHandler has to be registered as a Transient Service
            services.AddTransient<ProtectedApiBearerTokenHandler>();

            //Register a Typed Instance of HttpClientFactory for a Protected Resource
            //More info see: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-3.0

            services.AddHttpClient<IApiConnect, SampleApiConnect>(client =>
            {
                client.BaseAddress = new Uri(config["ApiResourceBaseUrls:SampleApi"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HttpContentMediaTypes.JSON));
            });
            


            //Register a Typed Instance of HttpClientFactory for AuthService 
            services.AddHttpClient<IAuthServerConnect, AuthServerConnect>();

            // Register the DiscoveryCache in DI and will use the HttpClientFactory to create clients. Cached for 24hrs by default
            services.AddSingleton<IDiscoveryCache>(r =>
            {
                var factory = r.GetRequiredService<IHttpClientFactory>();
                return new DiscoveryCache(config["ApiResourceBaseUrls:AuthServer"], () => factory.CreateClient());
            });
        }
    }
}
