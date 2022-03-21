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
        public int C_P_Id { get; set; }

        [Required]
        //[DataType(DataType.Text)]
        public string C_P_Salulation { get; set; }
        [Required]
        //[DataType(DataType.Text)]
        public string C_P_FirstName { get; set; }
        [Required]
        //[DataType(DataType.Text)]
        public string C_P_LastName { get; set; }
        [Required]
        //[EmailAddress]
        public string C_P_Email { get; set; }
        [Required]

        public string C_P_WorkPlace { get; set; }
        [Required]
        //[DataType(DataType.PhoneNumber)]
        public int C_P_Mobile { get; set; }

        [ForeignKey("CustID")]
        public int C_P_CustID { get; set; }
        public CustomersViewModel CustomersViewModels { get; set; }
    }
}
