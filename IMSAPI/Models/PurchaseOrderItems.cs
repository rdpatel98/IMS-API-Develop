using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("PurchaseOrderItems")]
    public class PurchaseOrderItems
    {
        [Key]
        public int PurchaseOrderItemsId { get; set; }
        public int PurchaseOrderId { get; set; }
        public short LineNo { get; set; }
        public int ItemId { get; set; }
        public int WarehouseId { get; set; }
        public double Quantity { get; set; }
        public int UnitId { get; set; }
        public double UnitPrice { get; set; }
        public double NetAmount { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}