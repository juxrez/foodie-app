using FoodieApp.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodieApp.Server.Infrastructure.Data.Configuration
{
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder
                .HasMany<Review>(m => m.Reviews)
                .WithOne(r => r.Meal)
                .HasForeignKey(r => r.MealId);

            builder
                .HasMany<Comment>(m => m.Comments)
                .WithOne(c => c.Meal)
                .HasForeignKey(c => c.MealId);

        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(c => c.UserId);
                
            
            builder
                .HasMany(u => u.Reviews)
                .WithOne(c => c.User)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(c => c.UserId);
        }
    }

    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            //builder
            //    .Property(c => c.UserId).IsRequired(false);

           
        }
    }
}
