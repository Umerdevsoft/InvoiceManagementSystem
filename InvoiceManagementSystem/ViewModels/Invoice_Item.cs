using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.ViewModels
{
    public class Invoice_Item
    {
        [Key]
        public int ID { get; set; }

        public int Invoice_ID { get; set; }
        public int Item_ID { get; set; }
        public string Item_Name { get; set; }
        public int Quantity { get; set; }
        public int Rate { get; set; }
        public string Discount { get; set; }
        public int Amount { get; set; }
        public InvoicesViewModels InvoicesViewModels { get; set; }
        public ItemsViewModels ItemsViewModels { get; set; }
    }
}
