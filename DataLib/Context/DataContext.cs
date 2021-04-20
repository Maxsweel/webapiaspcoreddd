using DataLib.Mapping;
using DomainLib.Entitys;
using Microsoft.EntityFrameworkCore;


namespace DataLib.Context
{
    public class DataContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DataContext (DbContextOptions<DataContext> options) : base(options) 
        {
            // Database.EnsureCreated();//Se não tiver o banco ele será criado na primeira utilização
            //Database.Migrate(); //Cria banco de dados caso não exista com esquema migration
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }
    }
}
