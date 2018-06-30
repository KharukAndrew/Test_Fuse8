namespace Test_Fuse8.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NorthwindDb : DbContext
    {
        public NorthwindDb()
            : base("name=NorthwindDb")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.RowTimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.RowTimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.RowTimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.Freight)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.RowTimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithOptional(e => e.Order)
                .WillCascadeOnDelete();

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.RowTimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.RowTimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Shipper>()
                .Property(e => e.RowTimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.RowTimeStamp)
                .IsFixedLength();
        }
    }
}
