using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.ViewModels
{
    public class ItemsViewModels
    {
        [Key]
        public int Item_ID { get; set; }
        [Required]
        public string Type { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        public string Unit { get; set; }

        [Required]

        public double SellingPrice { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required]
        public string Tax { get; set; }
        public List<Invoice_Item> Invoice_Items { get; set; }

    }
}
