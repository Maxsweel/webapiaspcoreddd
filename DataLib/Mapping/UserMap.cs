using DomainLib.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLib.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        //Configuração da tabela a ser chamada no DataContext
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.id);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.Property(u => u.Nome).IsRequired().HasMaxLength(100);
        }
    }
}
