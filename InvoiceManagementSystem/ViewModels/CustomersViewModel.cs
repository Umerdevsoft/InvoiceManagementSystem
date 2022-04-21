using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.ViewModels
{
    public class CustomersViewModel
    {
        [Key]
        public int CustID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Salutation { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string CustomerDisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string WorkPhone { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        
        [Required]
        public string C_CurrID { get; set; }
        
        public CurrencyViewModel CurrencyViewModel { get; set; }


        public IEnumerable<BillingViewModel> BillingViewModels { get; set; }

        public IEnumerable<ShippingViewModel> ShippingViewModels { get; set; }

        public IEnumerable<ContactPersonViewModel> ContactPersonViewModels { get; set; }

    }
}
