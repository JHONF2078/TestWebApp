
using TestWebApp.Entities;
using System.Linq;

namespace TestWebApp.DataAccess.Context
{
    public static class UserSeeder
    {
        public static void SeedInitialUsers(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { name = "Juan", lastName = "Pérez" },
                    new User { name = "Ana", lastName = "García" },
                    new User { name = "Luis", lastName = "Martínez" },
                    new User { name = "María", lastName = "López" },
                    new User { name = "Carlos", lastName = "Ramírez" }
                );

                context.SaveChanges();
            }
        }
    }
}
