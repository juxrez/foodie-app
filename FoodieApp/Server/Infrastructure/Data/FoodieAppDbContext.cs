using FoodieApp.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FoodieApp.Server.Infrastructure.Data.Configuration;
using System.Reflection;

namespace FoodieApp.Server.Infrastructure.Data
{
    public class FoodieAppDbContext : DbContext
    {
        public FoodieAppDbContext(DbContextOptions<FoodieAppDbContext> options) : base(options)
        {
                
        }

        public DbSet<Meal> Meal { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Comment> Comment { get; set; }

        /// <summary>
        /// Fluent API configurations
        /// ModelBuilder Fluent API instance is used to configure a property by calling multiple methods in a chain.
        /// Fluent API configurations have higher precedence than data annotation attributes.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This line scans all clases that inherits from IEntityTypeConfiguration
            //And run the Configure() Method to register its configuration
            //Each entity should have its on configuration 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
