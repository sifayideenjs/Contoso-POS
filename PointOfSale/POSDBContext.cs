using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    public class POSDBContext : DbContext
    {
        public POSDBContext() : base("name=POSContext")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());

            Database.SetInitializer<POSDBContext>(new CreateDatabaseIfNotExists<POSDBContext>());
            //Database.SetInitializer<POSDBContext>(new DropCreateDatabaseIfModelChanges<POSDBContext>());
            //Database.SetInitializer<POSDBContext>(new DropCreateDatabaseAlways<POSDBContext>());
            //Database.SetInitializer<POSDBContext>(new POSDBInitializer());
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceSub> InvoiceSubs { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
