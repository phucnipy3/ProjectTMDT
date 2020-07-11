using Microsoft.EntityFrameworkCore;
using Nhom2.TMDT.Data.Entities;

namespace Nhom2.TMDT.Data.Services
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<ShipmentDetail> ShipmentDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Category
            modelBuilder.Entity<Category>()
                .ToTable("Category");

            modelBuilder.Entity<Category>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .HasMaxLength(1000)
                .HasColumnType("NVARCHAR(1000)");

            modelBuilder.Entity<Category>()
               .Property(e => e.MetaTitle)
               .HasMaxLength(1000)
               .HasColumnType("VARCHAR(1000)");

            modelBuilder.Entity<Category>()
               .Property(e => e.ParentId);

            modelBuilder.Entity<Category>()
               .Property(e => e.CreatedDate)
               .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Category>()
               .Property(e => e.Status)
               .HasDefaultValue(true);

            modelBuilder.Entity<Category>()
                .HasOne(e => e.Parent)
                .WithMany(e => e.Children)
                .HasForeignKey(e => e.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Comment
            modelBuilder.Entity<Comment>()
                .ToTable("Comment");

            modelBuilder.Entity<Comment>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Content)
                .HasMaxLength(1000)
                .HasColumnType("NVARCHAR(1000)");

            modelBuilder.Entity<Comment>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Comment>()
                .Property(e => e.Status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Comment>()
                .HasOne(e => e.Parent)
                .WithMany(e => e.Children)
                .HasForeignKey(e => e.ParentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(e => e.Product)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(e => e.User)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Order
            modelBuilder.Entity<Order>()
                .ToTable("Order");

            modelBuilder.Entity<Order>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Order>()
                .Property(e => e.Note)
                .HasMaxLength(1000)
                .HasColumnType("NVARCHAR(1000)");

            modelBuilder.Entity<Order>()
                .Property(e => e.DeliveryMethod)
                .HasMaxLength(1000)
                .HasColumnType("NVARCHAR(1000)");

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalShipping)
                .HasColumnType("DECIMAL(18,0)");

            modelBuilder.Entity<Order>()
                .Property(e => e.PaymentMethod)
                .HasMaxLength(1000)
                .HasColumnType("NVARCHAR(1000)");

            modelBuilder.Entity<Order>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Order>()
                .Property(e => e.Ordered);

            modelBuilder.Entity<Order>()
                .Property(e => e.Confirmed);

            modelBuilder.Entity<Order>()
                .Property(e => e.Transporting);

            modelBuilder.Entity<Order>()
                .Property(e => e.Completed);

            modelBuilder.Entity<Order>()
                .Property(e => e.Canceled);

            modelBuilder.Entity<Order>()
                .Property(e => e.Deleted);

            modelBuilder.Entity<Order>()
                .Property(e => e.Status)
                .HasDefaultValue(0);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.User)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(e => e.ShipmentDetail)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.ShipmentDetailId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .ToTable("OrderDetail");

            modelBuilder.Entity<OrderDetail>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Count)
                .HasDefaultValue(1);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Price)
                .HasColumnType("DECIMAL(18,0)");

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.PromotionPrice)
                .HasColumnType("DECIMAL(18,0)");

            modelBuilder.Entity<OrderDetail>()
                .HasOne(e => e.Order)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(e => e.Product)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Product
            modelBuilder.Entity<Product>()
                .ToTable("Product");

            modelBuilder.Entity<Product>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .HasMaxLength(1000)
                .HasColumnType("NVARCHAR(1000)");

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaTitle)
                .HasMaxLength(1000)
                .HasColumnType("VARCHAR(1000)");

            modelBuilder.Entity<Product>()
                .Property(e => e.Brand)
                .HasMaxLength(1000)
                .HasColumnType("NVARCHAR(1000)");

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .HasMaxLength(1000)
                .HasColumnType("NVARCHAR(1000)");

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasColumnType("DECIMAL(18,0)");

            modelBuilder.Entity<Product>()
                .Property(e => e.PromotionPrice)
                .HasColumnType("DECIMAL(18,0)");

            modelBuilder.Entity<Product>()
                .Property(e => e.Quantity)
                .HasDefaultValue(0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Detail)
                .HasMaxLength(1000)
                .HasColumnType("NVARCHAR(1000)");

            modelBuilder.Entity<Product>()
                .Property(e => e.Warranty)
                .HasDefaultValue(0);

            modelBuilder.Entity<Product>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Product>()
                .Property(e => e.Status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Product>()
                .HasOne(e => e.Category)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Rate
            modelBuilder.Entity<Rate>()
                .ToTable("Rate");

            modelBuilder.Entity<Rate>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Rate>()
                .Property(e => e.RatePoint)
                .HasDefaultValue(0);

            modelBuilder.Entity<Rate>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Rate>()
                .HasOne(e => e.User)
                .WithMany(e => e.Rates)
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rate>()
                .HasOne(e => e.Product)
                .WithMany(e => e.Rates)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region ShipmentDetail
            modelBuilder.Entity<ShipmentDetail>()
                .ToTable("ShipmentDetail");

            modelBuilder.Entity<ShipmentDetail>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<ShipmentDetail>()
                .Property(e => e.Address)
                .HasMaxLength(1000)
                .HasColumnType("NVARCHAR(1000)");

            modelBuilder.Entity<ShipmentDetail>()
                .Property(e => e.Email)
                .HasMaxLength(500)
                .HasColumnType("NVARCHAR(500)");

            modelBuilder.Entity<ShipmentDetail>()
                .Property(e => e.PhoneNumber)
                .HasMaxLength(500)
                .HasColumnType("NVARCHAR(500)");

            modelBuilder.Entity<ShipmentDetail>()
                .HasOne(e => e.User)
                .WithMany(e => e.ShipmentDetails)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region User
            modelBuilder.Entity<User>()
                .ToTable("User");

            modelBuilder.Entity<User>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .HasMaxLength(500)
                .HasColumnType("NVARCHAR(500)");

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .HasMaxLength(1000)
                .HasColumnType("NVARCHAR(1000)");

            modelBuilder.Entity<User>()
                .Property(e => e.Role)
                .HasDefaultValue(3);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnType("NVARCHAR(500)");

            modelBuilder.Entity<User>()
                .Property(e => e.Sex)
                .HasDefaultValue(0);

            modelBuilder.Entity<User>()
                .Property(e => e.Image)
                .HasMaxLength(1000)
                .HasColumnType("NVARCHAR(1000)");

            modelBuilder.Entity<User>()
                .Property(e => e.Active)
                .HasDefaultValue(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Verification)
                .HasMaxLength(500)
                .HasColumnType("VARCHAR(500)");

            modelBuilder.Entity<User>()
                .Property(e => e.ExprireTime);

            modelBuilder.Entity<User>()
                .Property(e => e.Status)
                .HasDefaultValue(true);
            #endregion
        }
    }
}
