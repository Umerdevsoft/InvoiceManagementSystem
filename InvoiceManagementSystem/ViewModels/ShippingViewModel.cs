using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.ViewModels
{
    public class ShippingViewModel
    {

        [key]
        public int ID { get; set; }
        [Required]
        public string Attention { get; set; }
        [Required]
        public string Country_Region { get; set; }
        [Required]
        public string Address_Street1 { get; set; }
        [Required]
        public string Address_Street2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]

        public string State { get; set; }
        [Required]
        public int ZipCode { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public int Fax { get; set; }

        [ForeignKey("CustID")]
        public int CustID { get; set; }
        public CustomersViewModel CustomersViewModels { get; set; }
       
    }
}
