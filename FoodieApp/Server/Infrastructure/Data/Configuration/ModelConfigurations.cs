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

            builder
                .HasOne(m => m.User)
                .WithMany(c => c.Meals).
                OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(c => c.UserId);

            builder
                .HasOne(m => m.Group)
                .WithMany(g => g.Meals)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(g => g.GroupId);
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

    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .HasMany(g => g.Meals)
                .WithOne(m => m.Group)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(m => m.GroupId);
        }
    }

    public class GroupUserConfiguration : IEntityTypeConfiguration<GroupUser>
    {
        public void Configure(EntityTypeBuilder<GroupUser> builder)
        {
            builder
                .HasKey(gu => new { gu.UserId, gu.GroupId });

            builder.
                HasOne(u => u.User)
                .WithMany(gu => gu.GroupUsers)
                .HasForeignKey(gu => gu.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(c => c.Group)
                .WithMany(gu => gu.GroupUsers)
                .HasForeignKey(gu => gu.GroupId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
