using BanDoNoiThat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BanDoNoiThat.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Anh xa lop Models vao CSDL
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Customers>().ToTable("Customers");
            modelBuilder.Entity<OrderDetails>().ToTable("OrderDetails");
            modelBuilder.Entity<Orders>().ToTable("Orders");
            modelBuilder.Entity<Products>().ToTable("Products");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<Role>().ToTable("Role");

            // Tuy chinh khoa chinh (primary key)
            // Anh xa cot khoa chinh
            modelBuilder.Entity<Category>().Property(c => c.category_id).HasColumnName("category_id");
            modelBuilder.Entity<Customers>().Property(c => c.customer_id).HasColumnName("customer_id");
            modelBuilder.Entity<OrderDetails>().Property(o => o.detail_id).HasColumnName("detail_id");
            modelBuilder.Entity<Orders>().Property(o => o.order_id).HasColumnName("order_id");
            modelBuilder.Entity<Products>().Property(p => p.product_id).HasColumnName("product_id");
            modelBuilder.Entity<Account>().Property(a => a.account_id).HasColumnName("account_id");
            modelBuilder.Entity<Role>().Property(r => r.role_id).HasColumnName("role_id");

            // Xac dinh khoa chinh
            modelBuilder.Entity<Category>().HasKey(c => c.category_id);
            modelBuilder.Entity<Customers>().HasKey(c => c.customer_id);
            modelBuilder.Entity<OrderDetails>().HasKey(o => o.detail_id);
            modelBuilder.Entity<Orders>().HasKey(o => o.order_id);
            modelBuilder.Entity<Products>().HasKey(p => p.product_id);
            modelBuilder.Entity<Account>().HasKey(a => a.account_id);
            modelBuilder.Entity<Role>().HasKey(r => r.role_id);

            // Tuy chinh khoa ngoai (foreign key)
            modelBuilder.Entity<Orders>().HasOne(c => c.Customers).WithMany(o => o.Orders).HasForeignKey(c => c.customer_id);
            modelBuilder.Entity<Products>().HasOne(c => c.Category).WithMany(p => p.Products).HasForeignKey(c => c.category_id);
            modelBuilder.Entity<OrderDetails>().HasOne(o => o.Orders).WithMany(o => o.Order_details).HasForeignKey(o => o.order_id);
            modelBuilder.Entity<OrderDetails>().HasOne(p => p.Products).WithMany(o => o.Order_details).HasForeignKey(p => p.product_id);
            modelBuilder.Entity<Account>().HasOne(a => a.Role).WithMany(a => a.Accounts).HasForeignKey(a => a.role_id);
        }
    }
}
