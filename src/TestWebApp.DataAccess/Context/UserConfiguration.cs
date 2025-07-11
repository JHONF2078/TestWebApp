using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApp.Entities;

namespace TestWebApp.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> e)
        {
            e.ToTable("Usuario");

            e.HasKey(e => e.Id);

            e.Property(e => e.Id)
                .HasColumnName("usuId")
                .HasColumnType("numeric(18, 0)")
                 .ValueGeneratedOnAdd();

            e.Property(e => e.name)
                .HasColumnName("nombre")
                .HasMaxLength(100);                

            e.Property(e => e.lastName)
                .HasColumnName("apellido")
                .HasMaxLength(100);            

            
            e.HasData(
                new User { Id = 1, name = "Juan", lastName = "Pérez" },
                new User { Id = 2, name = "Ana", lastName = "García" },
                new User { Id = 3, name = "Luis", lastName = "Martínez" },
                new User { Id = 4, name = "María", lastName = "López" },
                new User { Id = 5, name = "Carlos", lastName = "Ramírez" }
            );
        }
    }
}
