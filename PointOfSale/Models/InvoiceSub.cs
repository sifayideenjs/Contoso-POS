using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Models
{
    public class InvoiceSub
    {
        public int InvoiceSubId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Item Item { get; set; }
        public double CostPrice { get; set; }
        public double SellPrice { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
    }
}
