using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace IMSAPI.Models.UnboxFutureContext
{
    public class StoreContext : IdentityDbContext<ApplicationUser>
    {
        public StoreContext()
            : base("name=StoreContext")
        {
            this.Database.Log = Console.Write;
            var adapter = (IObjectContextAdapter)this;
            var objectContext = adapter.ObjectContext;
            objectContext.CommandTimeout = 180;
        }


        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<UomConversion> UomConversions { get; set; }

        public DbSet<Items> Items { get; set; }

        public DbSet<Addresses> Addresses { get; set; }

        public DbSet<OrganizationAddress> OrganizationAddress { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<WorkerAddress> WorkerAddresses { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<VendorAddress> VendorAddresses { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<WarehouseAddress> WarehouseAddresses { get; set; }

        public DbSet<ItemCategory> ItemCategory { get; set; }

        public DbSet<ItemCategoryCollection> ItemCategoryCollection { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<PurchaseOrderItems> PurchaseOrderItems { get; set; }

        public DbSet<PurchaseReceive> PurchaseReceive { get; set; }

        public DbSet<PurchaseReceiveItems> PurchaseReceiveItems { get; set; }

        public DbSet<Invoice> Invoice { get; set; }

        public DbSet<InvoiceItems> InvoiceItems { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Transactions> Transactions { get; set; }

        public DbSet<InventoryAdjustment> InventoryAdjustment { get; set; }

        public DbSet<InventoryAdjustmentItems> InventoryAdjustmentItems { get; set; }

        public DbSet<Consumption> Consumption { get; set; }

        public DbSet<ConsumptionItems> ConsumptionItems { get; set; }

        public static StoreContext Create()
        {
            return new StoreContext();
        }
    }

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<StoreContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            //manager.PasswordValidator = new PasswordValidator
            //{
            //    RequiredLength = 6,
            //    RequireNonLetterOrDigit = true,
            //    RequireDigit = true,
            //    RequireLowercase = true,
            //    RequireUppercase = true,
            //};
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}