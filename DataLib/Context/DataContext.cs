using DomainLib.Entitys;
using Microsoft.EntityFrameworkCore;


namespace DataLib.Context
{
    public class DataContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DataContext (DbContextOptions<DataContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
