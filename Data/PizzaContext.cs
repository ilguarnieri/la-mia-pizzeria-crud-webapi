using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Data
{
    public class PizzaContext : IdentityDbContext<IdentityUser>
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options)
        {

        }
        public PizzaContext()
        {

        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Category> Categories { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db_pizzas;Integrated Security=True");
        }
    }
}
