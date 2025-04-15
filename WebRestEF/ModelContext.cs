using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderState> OrderStates { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<OrdersLine> OrdersLines { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPrice> ProductPrices { get; set; }

    public virtual DbSet<ProductStatus> ProductStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=3.239.12.168:1521/FREEPDB1;User ID=UD_tarunb;Password=UD_TARUNB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("UD_TARUNB")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("CUSTOMER_PK");

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(38)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.CustomerCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("CUSTOMER_CRTD_DT");
            entity.Property(e => e.CustomerCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CUSTOMER_CRTD_ID");
            entity.Property(e => e.CustomerDateOfBirth)
                .HasColumnType("DATE")
                .HasColumnName("CUSTOMER_DATE_OF_BIRTH");
            entity.Property(e => e.CustomerFirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_FIRST_NAME");
            entity.Property(e => e.CustomerGenderId)
                .HasMaxLength(38)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_GENDER_ID");
            entity.Property(e => e.CustomerLastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_LAST_NAME");
            entity.Property(e => e.CustomerMiddleName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_MIDDLE_NAME");
            entity.Property(e => e.CustomerUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("CUSTOMER_UPDT_DT");
            entity.Property(e => e.CustomerUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CUSTOMER_UPDT_ID");

            entity.HasOne(d => d.CustomerGender).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerGenderId)
                .HasConstraintName("CUSTOMER_FK1");
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => e.CustomerAddressId).HasName("CUSTOMER_ADDRESS_PK");

            entity.ToTable("CUSTOMER_ADDRESS");

            entity.Property(e => e.CustomerAddressId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_ADDRESS_ID");
            entity.Property(e => e.CustomerAddressActvInd)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("CUSTOMER_ADDRESS_ACTV_IND");
            entity.Property(e => e.CustomerAddressAddressId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_ADDRESS_ADDRESS_ID");
            entity.Property(e => e.CustomerAddressAddressTypeId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_ADDRESS_ADDRESS_TYPE_ID");
            entity.Property(e => e.CustomerAddressCrtdDt)
                .HasColumnType("DATE")
                .HasColumnName("CUSTOMER_ADDRESS_CRTD_DT");
            entity.Property(e => e.CustomerAddressCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_ADDRESS_CRTD_ID");
            entity.Property(e => e.CustomerAddressCustomerId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_ADDRESS_CUSTOMER_ID");
            entity.Property(e => e.CustomerAddressDefaultInd)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("CUSTOMER_ADDRESS_DEFAULT_IND");
            entity.Property(e => e.CustomerAddressUpdtDt)
                .HasColumnType("DATE")
                .HasColumnName("CUSTOMER_ADDRESS_UPDT_DT");
            entity.Property(e => e.CustomerAddressUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_ADDRESS_UPDT_ID");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("GENDER_PK");

            entity.ToTable("GENDER");

            entity.Property(e => e.GenderId)
                .HasMaxLength(38)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("sys_guid() ")
                .HasColumnName("GENDER_ID");
            entity.Property(e => e.GenderCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("GENDER_CRTD_DT");
            entity.Property(e => e.GenderCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("GENDER_CRTD_ID");
            entity.Property(e => e.GenderName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GENDER_NAME");
            entity.Property(e => e.GenderUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("GENDER_UPDT_DT");
            entity.Property(e => e.GenderUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("GENDER_UPDT_ID");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdersId).HasName("ORDERS_PK");

            entity.ToTable("ORDERS");

            entity.Property(e => e.OrdersId)
                .HasMaxLength(38)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDERS_ID");
            entity.Property(e => e.OrdersCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ORDERS_CRTD_DT");
            entity.Property(e => e.OrdersCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDERS_CRTD_ID");
            entity.Property(e => e.OrdersCustomerId)
                .HasMaxLength(38)
                .IsUnicode(false)
                .HasColumnName("ORDERS_CUSTOMER_ID");
            entity.Property(e => e.OrdersDate)
                .HasPrecision(6)
                .HasColumnName("ORDERS_DATE");
            entity.Property(e => e.OrdersUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ORDERS_UPDT_DT");
            entity.Property(e => e.OrdersUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDERS_UPDT_ID");

            entity.HasOne(d => d.OrdersCustomer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrdersCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ORDERS_FK1");
        });

        modelBuilder.Entity<OrderState>(entity =>
        {
            entity.HasKey(e => e.OrderStateId).HasName("ORDER_STATE_PK");

            entity.ToTable("ORDER_STATE");

            entity.Property(e => e.OrderStateId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ORDER_STATE_ID");
            entity.Property(e => e.OrderStateCrtdDt)
                .HasColumnType("DATE")
                .HasColumnName("ORDER_STATE_CRTD_DT");
            entity.Property(e => e.OrderStateCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ORDER_STATE_CRTD_ID");
            entity.Property(e => e.OrderStateEffDate)
                .HasColumnType("DATE")
                .HasColumnName("ORDER_STATE_EFF_DATE");
            entity.Property(e => e.OrderStateOrderStatusId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ORDER_STATE_ORDER_STATUS_ID");
            entity.Property(e => e.OrderStateOrdersId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ORDER_STATE_ORDERS_ID");
            entity.Property(e => e.OrderStateUpdtDt)
                .HasColumnType("DATE")
                .HasColumnName("ORDER_STATE_UPDT_DT");
            entity.Property(e => e.OrderStateUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ORDER_STATE_UPDT_ID");

            entity.HasOne(d => d.OrderStateOrderStatus).WithMany(p => p.OrderStates)
                .HasForeignKey(d => d.OrderStateOrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ORDER_STATE_FK2");

            entity.HasOne(d => d.OrderStateOrders).WithMany(p => p.OrderStates)
                .HasForeignKey(d => d.OrderStateOrdersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ORDER_STATE_FK1");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("ORDER_STATUS_PK");

            entity.ToTable("ORDER_STATUS");

            entity.Property(e => e.OrderStatusId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ORDER_STATUS_ID");
            entity.Property(e => e.OrderStatusCrtdDt)
                .HasColumnType("DATE")
                .HasColumnName("ORDER_STATUS_CRTD_DT");
            entity.Property(e => e.OrderStatusCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ORDER_STATUS_CRTD_ID");
            entity.Property(e => e.OrderStatusDesc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ORDER_STATUS_DESC");
            entity.Property(e => e.OrderStatusNextOrderStatusId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ORDER_STATUS_NEXT_ORDER_STATUS_ID");
            entity.Property(e => e.OrderStatusUpdtDt)
                .HasColumnType("DATE")
                .HasColumnName("ORDER_STATUS_UPDT_DT");
            entity.Property(e => e.OrderStatusUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ORDER_STATUS_UPDT_ID");

            entity.HasOne(d => d.OrderStatusNextOrderStatus).WithMany(p => p.InverseOrderStatusNextOrderStatus)
                .HasForeignKey(d => d.OrderStatusNextOrderStatusId)
                .HasConstraintName("ORDER_STATUS_FK1");
        });

        modelBuilder.Entity<OrdersLine>(entity =>
        {
            entity.HasKey(e => e.OrdersLineId).HasName("ORDERS_LINE_PK");

            entity.ToTable("ORDERS_LINE");

            entity.Property(e => e.OrdersLineId)
                .HasMaxLength(38)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDERS_LINE_ID");
            entity.Property(e => e.OrdersLineCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ORDERS_LINE_CRTD_DT");
            entity.Property(e => e.OrdersLineCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDERS_LINE_CRTD_ID");
            entity.Property(e => e.OrdersLineOrdersId)
                .HasMaxLength(38)
                .IsUnicode(false)
                .HasColumnName("ORDERS_LINE_ORDERS_ID");
            entity.Property(e => e.OrdersLinePrice)
                .HasColumnType("NUMBER(9,2)")
                .HasColumnName("ORDERS_LINE_PRICE");
            entity.Property(e => e.OrdersLineProductId)
                .HasMaxLength(38)
                .IsUnicode(false)
                .HasColumnName("ORDERS_LINE_PRODUCT_ID");
            entity.Property(e => e.OrdersLineQty)
                .HasPrecision(4)
                .HasColumnName("ORDERS_LINE_QTY");
            entity.Property(e => e.OrdersLineUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ORDERS_LINE_UPDT_DT");
            entity.Property(e => e.OrdersLineUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDERS_LINE_UPDT_ID");

            entity.HasOne(d => d.OrdersLineOrders).WithMany(p => p.OrdersLines)
                .HasForeignKey(d => d.OrdersLineOrdersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ORDERS_LINE_FK1");

            entity.HasOne(d => d.OrdersLineProduct).WithMany(p => p.OrdersLines)
                .HasForeignKey(d => d.OrdersLineProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ORDERS_LINE_FK2");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRODUCT_PK");

            entity.ToTable("PRODUCT");

            entity.Property(e => e.ProductId)
                .HasMaxLength(38)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.ProductCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_CRTD_DT");
            entity.Property(e => e.ProductCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_CRTD_ID");
            entity.Property(e => e.ProductDesc)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_DESC");
            entity.Property(e => e.ProductName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_NAME");
            entity.Property(e => e.ProductProductStatusId)
                .HasMaxLength(38)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_PRODUCT_STATUS_ID");
            entity.Property(e => e.ProductUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_UPDT_DT");
            entity.Property(e => e.ProductUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_UPDT_ID");

            entity.HasOne(d => d.ProductProductStatus).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductProductStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PRODUCT_FK1");
        });

        modelBuilder.Entity<ProductPrice>(entity =>
        {
            entity.HasKey(e => e.ProductPriceId).HasName("PRODUCT_PRICE_PK");

            entity.ToTable("PRODUCT_PRICE");

            entity.Property(e => e.ProductPriceId)
                .HasMaxLength(38)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_PRICE_ID");
            entity.Property(e => e.ProductPriceCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_PRICE_CRTD_DT");
            entity.Property(e => e.ProductPriceCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_PRICE_CRTD_ID");
            entity.Property(e => e.ProductPriceEffDate)
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_PRICE_EFF_DATE");
            entity.Property(e => e.ProductPricePrice)
                .HasColumnType("NUMBER(9,2)")
                .HasColumnName("PRODUCT_PRICE_PRICE");
            entity.Property(e => e.ProductPriceProductId)
                .HasMaxLength(38)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_PRICE_PRODUCT_ID");
            entity.Property(e => e.ProductPriceUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_PRICE_UPDT_DT");
            entity.Property(e => e.ProductPriceUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_PRICE_UPDT_ID");

            entity.HasOne(d => d.ProductPriceProduct).WithMany(p => p.ProductPrices)
                .HasForeignKey(d => d.ProductPriceProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PRODUCT_PRICE_FK1");
        });

        modelBuilder.Entity<ProductStatus>(entity =>
        {
            entity.HasKey(e => e.ProductStatusId).HasName("PRODUCT_STATUS_PK");

            entity.ToTable("PRODUCT_STATUS");

            entity.Property(e => e.ProductStatusId)
                .HasMaxLength(38)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_STATUS_ID");
            entity.Property(e => e.ProductStatusCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_STATUS_CRTD_DT");
            entity.Property(e => e.ProductStatusCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_STATUS_CRTD_ID");
            entity.Property(e => e.ProductStatusDesc)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_STATUS_DESC");
            entity.Property(e => e.ProductStatusUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_STATUS_UPDT_DT");
            entity.Property(e => e.ProductStatusUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_STATUS_UPDT_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
