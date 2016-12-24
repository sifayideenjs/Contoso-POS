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
    public class InvoiceRepository : IInvoiceRepository
    {
        private POSDBContext context;

        public InvoiceRepository(POSDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Invoice> Get()
        {
            return context.Invoices.ToList();
        }

        public Invoice GetByID(int id)
        {
            return context.Invoices.Find(id);
        }

        public void Insert(Invoice invoice)
        {
            context.Invoices.Add(invoice);
        }

        public void Delete(int ID)
        {
            Invoice invoice = context.Invoices.Find(ID);
            context.Invoices.Remove(invoice);
        }

        public void Update(Invoice invoice)
        {
            context.Entry(invoice).State = EntityState.Modified;
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        //raise a new exception inserting the current one as the InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                foreach(var entity in e.Entries)
                {
                    string message = entity.Entity.ToString();
                }
            }
            catch (Exception e)
            {
                string message = e.Message;
                throw;
            }
        }
    }
}
