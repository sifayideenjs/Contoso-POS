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
    public class InvoiceSubRepository : IInvoiceSubRepository
    {
        private POSDBContext context;

        public InvoiceSubRepository(POSDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<InvoiceSub> Get()
        {
            return context.InvoiceSubs.ToList();
        }

        public InvoiceSub GetByID(int id)
        {
            return context.InvoiceSubs.Find(id);
        }

        public void Insert(InvoiceSub invoiceSub)
        {
            context.InvoiceSubs.Add(invoiceSub);
        }

        public void Delete(int ID)
        {
            InvoiceSub invoiceSub = context.InvoiceSubs.Find(ID);
            context.InvoiceSubs.Remove(invoiceSub);
        }

        public void Update(InvoiceSub customer)
        {
            context.Entry(customer).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}