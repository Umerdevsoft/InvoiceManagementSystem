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

        public DbSet<ItemsViewModels> Items { get; set; }
        public DbSet<CustomersViewModel> Customers { get; set; }
        public DbSet<BillingViewModel> Billings { get; set; }
        public DbSet<ShippingViewModel> Shippings { get; set; }
        public DbSet<ContactPersonViewModel> ContactPerson { get; set; }


    }
}
