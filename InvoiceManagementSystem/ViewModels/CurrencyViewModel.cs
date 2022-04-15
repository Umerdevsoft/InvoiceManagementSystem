using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.ViewModels
{
    public class CurrencyViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string CurrencyNameWithCode { get; set; }

    }
}
