using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Customer Customer { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double FinalAmount { get; set; }
        public double Profit { get; set; }
        public virtual List<InvoiceSub> InvoiceSubs { get; set; }
    }
}
