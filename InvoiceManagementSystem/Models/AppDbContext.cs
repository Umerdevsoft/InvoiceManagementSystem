using InvoiceManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceManagementSystem.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CustomersViewModel> customersViewModels { get; set; }
        public DbSet<BillingViewModel> billingViewModels { get; set; }
        public DbSet<ShippingViewModel> shippingViewModels { get; set; }
        public DbSet<ContactPersonViewModel> contactPersonViewModels { get; set; }


    }
}
