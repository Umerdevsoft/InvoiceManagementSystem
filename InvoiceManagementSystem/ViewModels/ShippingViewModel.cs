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

        [Key]
        public int Shipping_Id { get; set; }
        [Required]
        public string S_Attention { get; set; }
        [Required]
        public string S_Country_Region { get; set; }
        [Required]
        public string S_Address_Street1 { get; set; }
        [Required]
        public string S_Address_Street2 { get; set; }
        [Required]
        public string S_City { get; set; }
        [Required]

        public string S_State { get; set; }
        [Required]
        public int S_ZipCode { get; set; }

        [Required]
        public int S_Phone { get; set; }

        [Required]
        public int S_Fax { get; set; }

        [ForeignKey("CustID")]
        public int S_CustID { get; set; }
        public CustomersViewModel CustomersViewModels { get; set; }

    }
}
