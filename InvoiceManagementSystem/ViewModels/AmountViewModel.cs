using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.ViewModels
{
    public class AmountViewModel
    {
        [Key]
        public int Amount_ID { get; set; }
        [Required]
        public int SubTotal { get; set; }
        [Required]
        public int Shipping { get; set; }
        [Required]
        public int Adjustment { get; set; }
        [Required]
        public int TotalAmount { get; set; }

        [ForeignKey("Invoice_ID")]
        public int Invoice_ID { get; set; }
        public InvoicesViewModels InvoicesViewModels { get; set; }
    }
}
