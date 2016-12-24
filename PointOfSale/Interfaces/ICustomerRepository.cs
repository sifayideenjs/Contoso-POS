using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Get();
        Customer GetByID(int Id);
        void Insert(Customer customer);
        void Delete(int ID);
        void Update(Customer customer);
        void Save();
    }
}
