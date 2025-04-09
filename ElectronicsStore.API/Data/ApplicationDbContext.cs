using Microsoft.EntityFrameworkCore;
using ElectronicsStore.API.Models;

namespace ElectronicsStore.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Product configuration
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Price)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Description)
                    .IsRequired();
            });

            // Order configuration
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(o => o.TotalAmount)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.HasOne(o => o.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // OrderItem configuration
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(oi => oi.UnitPrice)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.HasOne(oi => oi.Order)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(oi => oi.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(oi => oi.Product)
                    .WithMany()
                    .HasForeignKey(oi => oi.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(u => u.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            // ✅ Seed sample laptop products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 10,
                    Name = "MacBook Air M2",
                    Description = "13-inch, 2023, 8GB RAM, 256GB SSD",
                    Price = 99999m,
                    Category = "Laptop",
                    ImageUrl = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/mba15-skyblue-select-202503?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1741885366344"
                },
                new Product
                {
                    Id = 11,
                    Name = "Lenovo IdeaPad Slim 5",
                    Description = "15.6-inch, Ryzen 7, 16GB RAM",
                    Price = 59999m,
                    Category = "Laptop",
                    ImageUrl = "https://p1-ofp.static.pub/ShareResource/na/products/ideapad/1060x596/lenovo-ideapad-slim-5-16inch-amd-abyss-blue-01.png"
                },
                new Product
                {
                    Id = 12,
                    Name = "HP Pavilion x360",
                    Description = "14-inch, i5, 8GB RAM, 512GB SSD",
                    Price = 65999m,
                    Category = "Laptop",
                    ImageUrl = "https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c08928130.png?imwidth=270&imdensity=1&impolicy=Png_Res"
                }
            );
        }
    }
}
