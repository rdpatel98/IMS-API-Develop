using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace IMSAPI.Models.UnboxFutureContext
{
    public class StoreContext : DbContext
    {
        public StoreContext()
            : base("name=StoreContext")
        {
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
    }
}