using DomainLib.Interfaces.Services.User;
using Microsoft.Extensions.DependencyInjection;
using ServiceLib.Services;
using System;

namespace CrossCuttingLib.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
            {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}
