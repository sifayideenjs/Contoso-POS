using PointOfSale.Models;
using PointOfSale.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.DAL
{
    public static class DataSet
    {
        public static void PopulateDataSet()
        {
            POSDBContext context = new POSDBContext();
            //context.Database.Initialize(true);

            Customer customer01 = new Customer() { Name = "Sifayideen" };
            Customer customer02 = new Customer() { Name = "Kasim" };

            CustomerRepository customerRepository = new CustomerRepository(context);
            customerRepository.Insert(customer01);
            customerRepository.Insert(customer02);
            customerRepository.Save();

            Item item01 = new Item() { Name = "Colgate", Price = 50 };
            Item item02 = new Item() { Name = "Cintol", Price = 40 };
            Item item03 = new Item() { Name = "Lifeboy", Price = 60 };
            ItemRepository itemRepository = new ItemRepository(context);
            itemRepository.Insert(item01);
            itemRepository.Insert(item02);
            itemRepository.Insert(item03);
            itemRepository.Save();

            Invoice invoice01 = new Invoice() { Name = "Invoice 01", Customer = customer01, Discount = 0, Tax = 4, DateTime = DateTime.Now };
            Invoice invoice02 = new Invoice() { Name = "Invoice 02", Customer = customer02, Discount = 0, Tax = 4, DateTime = DateTime.Now };

            InvoiceRepository invoiceRepository = new InvoiceRepository(context);
            invoiceRepository.Insert(invoice01);
            invoiceRepository.Insert(invoice02);
            invoiceRepository.Save();

            InvoiceSub invoiceSub01 = new InvoiceSub() { Item = item01, Unit = "Piece", CostPrice = item01.Price, SellPrice = 55, Quantity = 10, Amount = 55 * 10, Invoice = invoice01 };
            InvoiceSub invoiceSub02 = new InvoiceSub() { Item = item02, Unit = "Piece", CostPrice = item02.Price, SellPrice = 45, Quantity = 10, Amount = 45 * 10, Invoice = invoice01 };
            InvoiceSub invoiceSub03 = new InvoiceSub() { Item = item03, Unit = "Piece", CostPrice = item03.Price, SellPrice = 65, Quantity = 10, Amount = 65 * 10, Invoice = invoice01 };
            invoice01.Amount = invoiceSub01.Amount + invoiceSub02.Amount + invoiceSub03.Amount;
            invoice01.Profit = ((invoiceSub01.SellPrice - invoiceSub01.CostPrice) * invoiceSub01.Quantity) + ((invoiceSub02.SellPrice - invoiceSub02.CostPrice) * invoiceSub02.Quantity) + ((invoiceSub03.SellPrice - invoiceSub03.CostPrice) * invoiceSub03.Quantity);
            invoice01.FinalAmount = invoice01.Amount + (invoice01.Amount * (invoice01.Discount / 100.0)) + (invoice01.Amount * (invoice01.Tax / 100.0));

            InvoiceSub invoiceSub04 = new InvoiceSub() { Item = item01, Unit = "Piece", CostPrice = item01.Price, SellPrice = 55, Quantity = 10, Amount = 55 * 10, Invoice = invoice02 };
            InvoiceSub invoiceSub05 = new InvoiceSub() { Item = item02, Unit = "Piece", CostPrice = item02.Price, SellPrice = 45, Quantity = 10, Amount = 45 * 10, Invoice = invoice02 };
            invoice02.Amount = invoiceSub04.Amount + invoiceSub05.Amount;
            invoice02.Profit = ((invoiceSub04.SellPrice - invoiceSub04.CostPrice) * invoiceSub04.Quantity) + ((invoiceSub05.SellPrice - invoiceSub05.CostPrice) * invoiceSub05.Quantity);
            invoice02.FinalAmount = invoice02.Amount + (invoice02.Amount * (invoice02.Discount / 100.0)) + (invoice02.Amount * (invoice02.Tax / 100.0));

            InvoiceSubRepository invoiceSubRepository = new InvoiceSubRepository(context);
            invoiceSubRepository.Insert(invoiceSub01);
            invoiceSubRepository.Insert(invoiceSub02);
            invoiceSubRepository.Insert(invoiceSub03);
            invoiceSubRepository.Insert(invoiceSub04);
            invoiceSubRepository.Insert(invoiceSub05);
            invoiceSubRepository.Save();

            invoiceSubRepository.Save();
            invoiceRepository.Save();
        }
    }
}
