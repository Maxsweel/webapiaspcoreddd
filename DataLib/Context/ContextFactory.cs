using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;



namespace DataLib.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var Connection = "Server=localhost;port=3306;Database=dbAPI;Uid=root;Pwd=max123";
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(Connection);
            return new DataContext(optionsBuilder.Options);
        }
    }
}
