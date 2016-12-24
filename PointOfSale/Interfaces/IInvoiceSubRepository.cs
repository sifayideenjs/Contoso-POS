using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Interfaces
{
    public interface IInvoiceSubRepository
    {
        IEnumerable<InvoiceSub> Get();
        InvoiceSub GetByID(int Id);
        void Insert(InvoiceSub invoiceSub);
        void Delete(int ID);
        void Update(InvoiceSub invoiceSub);
        void Save();
    }
}
