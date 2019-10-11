using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBClientApp
{
    using System.Data.Entity;
    
    public class Customer
    {
        public string CustomerId { get; set; }

        public decimal Credit { get; set; }

        //virtual navigation property - atomatically (lazy) loads child entities
        public virtual ICollection<Order> Orders { get; set; }

    }

    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerId { get; set; }

        public int ProductNo { get; set; }

        public int Quantity { get; set; }
    }

    public class CustomerModel : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("Customer");

            modelBuilder.Entity<Order>()
                .ToTable("OrderDetail")
                .Property(p => p.Id)
                .HasColumnName("OrderNo");
        }

    }
}
