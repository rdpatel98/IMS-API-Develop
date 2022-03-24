using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("InventoryAdjustmentItems")]
    public class InventoryAdjustmentItems
    {
        [Key]
        public int InventoryAdjustmentItemsId { get; set; }
        public int InventoryAdjustmentId { get; set; }
        public Int16 LineNo { get; set; }
        public int ItemId { get; set; }
        public int WarehouseId { get; set; }
        public int WorkerId { get; set; }
        public double Quantity { get; set; }
        public byte ReasonCode { get; set; }
        public string Reason { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}