using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("InventoryAdjustment")]
    public class InventoryAdjustment
    {
        [Key]
        public int InventoryAdjustmentId { get; set; }
        public string InventoryAdjustmentNo { get; set; }
        public DateTime AdjustmentDate { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public short Status { get; set; }
        public int OrganizationId { get; set; }
        public int WarehouseId { get; set; }
        public int WorkerId { get; set; }
    }
}