using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Interfaces
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> Get();
        Invoice GetByID(int Id);
        void Insert(Invoice invoice);
        void Delete(int ID);
        void Update(Invoice invoice);
        void Save();
    }
}
