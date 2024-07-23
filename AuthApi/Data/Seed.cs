using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace AuthApi.Data
{
    public class Seed
    {
        public static void Population(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DataContext>());
            }
        }
        public static void SeedData(DataContext context)
        {
            //context.Database.EnsureCreated();
            context.Database.Migrate();

            if (context.Users.Any())
            {
                return;
            }
            var userData = System.IO.File.ReadAllText("Data/Seed/users.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();
                user.Username = user.Username.ToLower();
                // cremos password encriptos pero que sean password para pruebas
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));
                user.PasswordSalt = hmac.Key;
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}
