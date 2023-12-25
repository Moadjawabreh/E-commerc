using MedicalTools.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalTools.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option):base(option)
        {

        }

        public DbSet<User> users { get; set; }

        public DbSet<Category> categories { get; set; }

        public DbSet<Product> products { get; set; }

        public DbSet<Image> images { get; set; }

        public DbSet<FeedbackForProduct> feedbackForProducts { get; set; }

        public DbSet<FeedbackForWeb> feedbackForWebs { get; set; }

        public DbSet<Payment> payments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(u => u.FeedbackForProducts)
                    .WithOne(f => f.User)
                    .HasForeignKey(f => f.userID)
                    .IsRequired();

                entity.HasMany(u => u.FeedbackForWebs)
                    .WithOne(f => f.User)
                    .HasForeignKey(f => f.userID)
                    .IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasMany(u => u.Images)
                    .WithOne(f => f.Product)
                    .HasForeignKey(f => f.productID)
                    .IsRequired();

                entity.HasMany(u => u.FeedbackForProducts)
                    .WithOne(f => f.Product)
                    .HasForeignKey(f => f.productID)
                    .IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany(u => u.Products)
                    .WithOne(f => f.Category)
                    .HasForeignKey(f => f.categoryID)
                    .IsRequired();
            });


            }
    }
}
