using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.ViewModels
{
    public class ContactPersonViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Salulation { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
       
        public string WorkPlace { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Mobile { get; set; }

        [ForeignKey("CustID")]
        public int CustID { get; set; }
        public CustomersViewModel CustomersViewModels { get; set; }
    }
}
