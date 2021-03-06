using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.ViewModels
{
    public class InvoicesViewModels
    {
        [Key]
        public int Invoice_ID { get; set; }
        [Required]
        public int InvoiceNumber { get; set; }
        [Required]
        public string InvoiceNumberString { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public string Terms { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public string Subject { get; set; }

        public string Status { get; set; }
        public string CustomerNote { get; set; }



        [ForeignKey("SalePerson_ID")]
        public int SalePerson_ID { get; set; }


        public SalesPersonsViewModel salesPersonsViewModel { get; set; }

        [ForeignKey("Invoice_Cust_ID")]
        public int Invoice_Cust_ID { get; set; }

        public CustomersViewModel Customers { get; set; }

        public List<Invoice_Item> Invoice_Items { get; set; }
        public List<AmountViewModel> Amounts { get; set; }

    }
}
