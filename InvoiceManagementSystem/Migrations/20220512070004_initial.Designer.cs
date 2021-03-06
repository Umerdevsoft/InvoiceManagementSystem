// <auto-generated />
using System;
using InvoiceManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InvoiceManagementSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220512070004_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("InvoiceManagementSystem.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.AmountViewModel", b =>
                {
                    b.Property<int>("Amount_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Adjustment")
                        .HasColumnType("int");

                    b.Property<int>("Invoice_ID")
                        .HasColumnType("int");

                    b.Property<int?>("InvoicesViewModelsInvoice_ID")
                        .HasColumnType("int");

                    b.Property<int>("Shipping")
                        .HasColumnType("int");

                    b.Property<int>("SubTotal")
                        .HasColumnType("int");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.HasKey("Amount_ID");

                    b.HasIndex("InvoicesViewModelsInvoice_ID");

                    b.ToTable("Amounts");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.BillingViewModel", b =>
                {
                    b.Property<int>("Billing_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("B_Address_Street1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B_Address_Street2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B_Attention")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B_City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B_Country_Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("B_CustID")
                        .HasColumnType("int");

                    b.Property<string>("B_Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B_State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("B_ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomersViewModelsCustID")
                        .HasColumnType("int");

                    b.HasKey("Billing_Id");

                    b.HasIndex("CustomersViewModelsCustID");

                    b.ToTable("Billings");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.ContactPersonViewModel", b =>
                {
                    b.Property<int>("C_P_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("C_P_CustID")
                        .HasColumnType("int");

                    b.Property<string>("C_P_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C_P_FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C_P_LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C_P_Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C_P_Salulation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C_P_WorkPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomersViewModelsCustID")
                        .HasColumnType("int");

                    b.HasKey("C_P_Id");

                    b.HasIndex("CustomersViewModelsCustID");

                    b.ToTable("ContactPerson");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.CurrencyViewModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CurrencyNameWithCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.CustomersViewModel", b =>
                {
                    b.Property<int>("CustID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("C_CurrID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurrencyViewModelID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerDisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salutation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkPhone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustID");

                    b.HasIndex("CurrencyViewModelID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.Invoice_Item", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Discount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Invoice_ID")
                        .HasColumnType("int");

                    b.Property<int?>("InvoicesViewModelsInvoice_ID")
                        .HasColumnType("int");

                    b.Property<int>("Item_ID")
                        .HasColumnType("int");

                    b.Property<string>("Item_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ItemsViewModelsItem_ID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("InvoicesViewModelsInvoice_ID");

                    b.HasIndex("ItemsViewModelsItem_ID");

                    b.ToTable("Invoice_Items");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.InvoicesViewModels", b =>
                {
                    b.Property<int>("Invoice_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CustomerNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomersCustID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvoiceNumber")
                        .HasColumnType("int");

                    b.Property<string>("InvoiceNumberString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Invoice_Cust_ID")
                        .HasColumnType("int");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SalePerson_ID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Terms")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("salesPersonsViewModelID")
                        .HasColumnType("int");

                    b.HasKey("Invoice_ID");

                    b.HasIndex("CustomersCustID");

                    b.HasIndex("salesPersonsViewModelID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.ItemsViewModels", b =>
                {
                    b.Property<int>("Item_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SellingPrice")
                        .HasColumnType("float");

                    b.Property<string>("Tax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Item_ID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.SalesPersonsViewModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("SalesPerson");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.ShippingViewModel", b =>
                {
                    b.Property<int>("Shipping_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CustomersViewModelsCustID")
                        .HasColumnType("int");

                    b.Property<string>("S_Address_Street1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("S_Address_Street2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("S_Attention")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("S_City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("S_Country_Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("S_CustID")
                        .HasColumnType("int");

                    b.Property<string>("S_Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("S_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("S_State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("S_ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Shipping_Id");

                    b.HasIndex("CustomersViewModelsCustID");

                    b.ToTable("Shippings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.AmountViewModel", b =>
                {
                    b.HasOne("InvoiceManagementSystem.ViewModels.InvoicesViewModels", "InvoicesViewModels")
                        .WithMany("Amounts")
                        .HasForeignKey("InvoicesViewModelsInvoice_ID");

                    b.Navigation("InvoicesViewModels");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.BillingViewModel", b =>
                {
                    b.HasOne("InvoiceManagementSystem.ViewModels.CustomersViewModel", "CustomersViewModels")
                        .WithMany("BillingViewModels")
                        .HasForeignKey("CustomersViewModelsCustID");

                    b.Navigation("CustomersViewModels");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.ContactPersonViewModel", b =>
                {
                    b.HasOne("InvoiceManagementSystem.ViewModels.CustomersViewModel", "CustomersViewModels")
                        .WithMany("ContactPersonViewModels")
                        .HasForeignKey("CustomersViewModelsCustID");

                    b.Navigation("CustomersViewModels");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.CustomersViewModel", b =>
                {
                    b.HasOne("InvoiceManagementSystem.ViewModels.CurrencyViewModel", "CurrencyViewModel")
                        .WithMany()
                        .HasForeignKey("CurrencyViewModelID");

                    b.Navigation("CurrencyViewModel");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.Invoice_Item", b =>
                {
                    b.HasOne("InvoiceManagementSystem.ViewModels.InvoicesViewModels", "InvoicesViewModels")
                        .WithMany("Invoice_Items")
                        .HasForeignKey("InvoicesViewModelsInvoice_ID");

                    b.HasOne("InvoiceManagementSystem.ViewModels.ItemsViewModels", "ItemsViewModels")
                        .WithMany("Invoice_Items")
                        .HasForeignKey("ItemsViewModelsItem_ID");

                    b.Navigation("InvoicesViewModels");

                    b.Navigation("ItemsViewModels");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.InvoicesViewModels", b =>
                {
                    b.HasOne("InvoiceManagementSystem.ViewModels.CustomersViewModel", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomersCustID");

                    b.HasOne("InvoiceManagementSystem.ViewModels.SalesPersonsViewModel", "salesPersonsViewModel")
                        .WithMany()
                        .HasForeignKey("salesPersonsViewModelID");

                    b.Navigation("Customers");

                    b.Navigation("salesPersonsViewModel");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.ShippingViewModel", b =>
                {
                    b.HasOne("InvoiceManagementSystem.ViewModels.CustomersViewModel", "CustomersViewModels")
                        .WithMany("ShippingViewModels")
                        .HasForeignKey("CustomersViewModelsCustID");

                    b.Navigation("CustomersViewModels");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("InvoiceManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("InvoiceManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InvoiceManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("InvoiceManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.CustomersViewModel", b =>
                {
                    b.Navigation("BillingViewModels");

                    b.Navigation("ContactPersonViewModels");

                    b.Navigation("ShippingViewModels");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.InvoicesViewModels", b =>
                {
                    b.Navigation("Amounts");

                    b.Navigation("Invoice_Items");
                });

            modelBuilder.Entity("InvoiceManagementSystem.ViewModels.ItemsViewModels", b =>
                {
                    b.Navigation("Invoice_Items");
                });
#pragma warning restore 612, 618
        }
    }
}
