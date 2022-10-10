using DishBurger.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DishBurger.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient_Dish>().HasKey(am => new
            {
                am.IngredientId,
                am.DishId
            });

            modelBuilder.Entity<Ingredient_Dish>().HasOne(m => m.Dish).WithMany(am => am.Ingredient_Dish).HasForeignKey(m => m.DishId);
            modelBuilder.Entity<Ingredient_Dish>().HasOne(m => m.Ingredient).WithMany(am => am.Ingredient_Dish).HasForeignKey(m => m.IngredientId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient_Dish> Ingredient_Dish { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ItemEntity> ItemEntitys { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
