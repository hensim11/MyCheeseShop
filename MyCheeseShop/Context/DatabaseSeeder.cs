using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;


namespace MyCheeseShop.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if (!_context.Users.Any())
            {
               
            
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

                var adminEmail = "admin@cheese.com";
                var adminPassword = "Cheese123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Admin Street",
                    City = "Adminville",
                    PostCode = "AD12 MIN",

                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");
            }
            if (!_context.Cheeses.Any())
            {
                var cheeses = GetCheeses();
                _context.Cheeses.AddRange(cheeses);
                await _context.SaveChangesAsync();
            }
            

        }

        private List<Cheese> GetCheeses()
        {
            return
            [
                new Cheese { Name = "Cheddar", Type = "Hard", Description = "Sharp and tangy", Strength = "Medium", Price = 10.99m, ImageUrl="Cheddar.png"},
                new Cheese { Name = "Brie", Type = "Soft", Description = "Creamy and buttery", Strength = "Mild", Price = 12.49m, ImageUrl="Brie.png" },
                new Cheese { Name = "Gouda", Type = "Semi-hard", Description = "Smooth and nutty", Strength = "Medium", Price = 9.75m, ImageUrl="Gouda.png" },
                new Cheese { Name = "Blue Cheese", Type = "Soft", Description = "Strong and pungent", Strength = "Strong", Price = 14.99m, ImageUrl="BlueCheese.png" },
                new Cheese { Name = "Parmesan", Type = "Hard", Description = "Salty and savory", Strength = "Strong", Price = 11.25m, ImageUrl="Parmesan.png" },
                new Cheese { Name = "Goat Cheese", Type = "Soft", Description = "Tangy and earthy", Strength = "Mild", Price = 13.99m, ImageUrl="GoatCheese.png" },
                new Cheese { Name = "Gruyere", Type = "Hard", Description = "Rich and nutty", Strength = "Medium", Price = 15.75m, ImageUrl="Gruyere.png" },
                new Cheese { Name = "Mozzarella", Type = "Soft", Description = "Mild and milky", Strength = "Mild", Price = 8.99m, ImageUrl="Mozzarella.png" },
                new Cheese { Name = "Swiss Cheese", Type = "Hard", Description = "Sweet and nutty", Strength = "Medium", Price = 10.25m, ImageUrl="SwissCheese.png" },
                new Cheese { Name = "Feta Cheese", Type = "Soft", Description = "Tangy and salty", Strength = "Strong", Price = 13.49m, ImageUrl="Feta.png" },
                new Cheese { Name = "Provolone", Type = "Semi-hard", Description = "Sharp and smooth", Strength = "Medium", Price = 9.99m, ImageUrl="Provolone.png" },
                new Cheese { Name = "Camembert", Type = "Soft", Description = "Creamy and earthy", Strength = "Mild", Price = 11.99m, ImageUrl="Camembert.png" },
                new Cheese { Name = "Manchego", Type = "Hard", Description = "Nutty and rich", Strength = "Medium", Price = 12.75m, ImageUrl="Manchego.png" },
                new Cheese { Name = "Havarti", Type = "Semi-soft", Description = "Creamy and buttery", Strength = "Mild", Price = 10.49m, ImageUrl="Havarti.png" },
                new Cheese { Name = "Roquefort", Type = "Soft", Description = "Sharp and tangy", Strength = "Strong", Price = 16.25m, ImageUrl="Roquefort.png" },
                new Cheese { Name = "Emmental", Type = "Hard", Description = "Sweet and nutty", Strength = "Medium", Price = 14.99m, ImageUrl="Emmental.png" },
                new Cheese { Name = "Colby Jack", Type = "Semi-hard", Description = "Mild and mellow", Strength = "Mild", Price = 9.25m, ImageUrl="ColbyJack.png" },
                new Cheese { Name = "Ricotta", Type = "Soft", Description = "Creamy and slightly sweet", Strength = "Mild", Price = 7.99m, ImageUrl="Ricotta.png" },
                new Cheese { Name = "Pepper Jack", Type = "Semi-soft", Description = "Spicy and creamy", Strength = "Medium", Price = 10.99m, ImageUrl="PepperJack.png" },
                new Cheese { Name = "Taleggio", Type = "Soft", Description = "Fruity and tangy", Strength = "Strong", Price = 14.49m, ImageUrl="Taleggio.png" }

            ];
        }







    }
}
