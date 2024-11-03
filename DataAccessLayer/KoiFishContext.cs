using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects.Models;

public partial class KoiFishContext : DbContext
{
    public KoiFishContext()
    {
    }

    public KoiFishContext(DbContextOptions<KoiFishContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnectionStringDB"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__23CAF1F815861058");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.ToTable("koiFish");

            entity.Property(e => e.KoiFishId).HasColumnName("koiFishID");
            entity.Property(e => e.AwardCertificate)
                .HasMaxLength(100)
                .HasColumnName("awardCertificate");
            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.HealthStatus).HasColumnName("healthStatus");
            entity.Property(e => e.KoiFishImage)
                .HasMaxLength(100)
                .HasColumnName("koiFishImage");
            entity.Property(e => e.KoiFishName)
                .HasMaxLength(100)
                .HasColumnName("koiFishName");
            entity.Property(e => e.KoiFishPrice).HasColumnName("koiFishPrice");
            entity.Property(e => e.KoiFishQuantity).HasColumnName("koiFishQuantity");
            entity.Property(e => e.Length).HasColumnName("length");
            entity.Property(e => e.Origin)
                .HasMaxLength(100)
                .HasColumnName("origin");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Category).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK_order");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId)
                .HasMaxLength(40)
                .HasColumnName("orderID");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalMoney).HasColumnName("totalMoney");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Service).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_service");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_user");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.KoiFishId }).HasName("PK_orderDetail");

            entity.ToTable("orderDetails");

            entity.Property(e => e.OrderId)
                .HasMaxLength(40)
                .HasColumnName("orderID");
            entity.Property(e => e.KoiFishId).HasColumnName("koiFishID");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.KoiFish).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.KoiFishId)
                .HasConstraintName("FK_koiFishDetail");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_orderDetail");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Service__4550733FCAB23338");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceId).HasColumnName("serviceID");
            entity.Property(e => e.PriceConsign).HasColumnName("priceConsign");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(100)
                .HasColumnName("serviceName");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__CB9A1CDFAB250C06");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("fullName");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId)
                .HasMaxLength(50)
                .HasColumnName("roleID");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
