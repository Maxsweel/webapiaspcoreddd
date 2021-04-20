using DataLib.Context;
using DataLib.Repository;
using DomainLib.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace CrossCuttingLib.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddDbContext<DataContext>(options => options.UseMySql("Server=localhost;port=3306;Database=dbAPI;Uid=root;Pwd=max123"));
        }
    }
}
