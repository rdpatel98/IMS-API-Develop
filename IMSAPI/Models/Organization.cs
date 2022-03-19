using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("Organization")]
    public class Organization
    {
        [Key]
        public Int32 OrganizationId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PurchaseOrderPrefix { get; set; }
        public string ReturnOrderPrefix { get; set; }
        public string InventoryAdjustmentPrefix { get; set; }
        public string ItemConsumptionPrefix { get; set; }
        public Int32 TransactionalWarehouseId { get; set; }
        [NotMapped]
        public string TransactionalWarehouse { get; set; }
        public string TaxRegistrationNumber { get; set; }
        public Int32 UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public Int16 Status { get; set; }
    }
}