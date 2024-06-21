
using Microsoft.Extensions.DependencyInjection;
using SGT.Application.Abstraction.Token;
using SGT.Application.Services;
using SGT.Infrasturcture.Services.Token;

namespace SGT.Infrasturcture
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
            serviceCollection.AddScoped<IMailService, IMailService>();
        }
    }
}
