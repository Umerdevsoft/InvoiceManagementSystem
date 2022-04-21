using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.ViewModels
{
    public class BillingViewModel
    {
        [Key]
        public int Billing_Id { get; set; }
        [Required]
        public string B_Attention { get; set; }
        [Required]
        public string B_Country_Region { get; set; }
        [Required]
        public string B_Address_Street1 { get; set; }
        [Required]
        public string B_Address_Street2 { get; set; }
        [Required]
        public string B_City { get; set; }
        [Required]

        public string B_State { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string B_ZipCode { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string B_Phone { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string B_Fax { get; set; }

        [ForeignKey("CustID")]
        public int B_CustID { get; set; }
        public CustomersViewModel CustomersViewModels { get; set; }
    }
}
