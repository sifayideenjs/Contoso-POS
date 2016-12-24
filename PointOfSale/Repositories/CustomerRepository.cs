using PointOfSale.Interfaces;
using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private POSDBContext context;

        public CustomerRepository(POSDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Customer> Get()
        {
            return context.Customers.ToList();
        }

        public Customer GetByID(int id)
        {
            return context.Customers.Find(id);
        }

        public void Insert(Customer customer)
        {
            context.Customers.Add(customer);
        }

        public void Delete(int ID)
        {
            Customer customer = context.Customers.Find(ID);
            context.Customers.Remove(customer);
        }

        public void Update(Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}