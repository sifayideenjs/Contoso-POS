using PointOfSale.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PointOfSale.XamlHelper
{
    public class ControlDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultDataTemplate { get; set; }
        public DataTemplate SaleInvoiceDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item is AllInvoiceViewModel)
            {
                return DefaultDataTemplate;
            }
            else if(item is SaleInvoiceViewModel)
            {
                return SaleInvoiceDataTemplate;
            }

            return DefaultDataTemplate;
        }
    }
}
