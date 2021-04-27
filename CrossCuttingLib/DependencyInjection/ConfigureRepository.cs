using DataLib.Context;
using DataLib.Implementations;
using DataLib.Repository;
using DomainLib.Interfaces;
using DomainLib.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace CrossCuttingLib.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();// login

            serviceCollection.AddDbContext<DataContext>(options => options.UseMySql("Server=localhost;port=3306;Database=dbAPI;Uid=root;Pwd=max123"));
        }
    }
}
