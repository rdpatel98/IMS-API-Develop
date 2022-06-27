using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("Items")]
    public class Items
    {
        [Key]
        public int ItemId { get; set; }
        public string Id { get; set; }
        public string ItemNo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PurchaseUnitId { get; set; }
        [NotMapped]
        public string PurchaseUnit { get; set; }
        public int InventoryUnitId { get; set; }
        [NotMapped]
        public string InventoryUnit { get; set; }
        public double MinStock { get; set; }
        public double MaxStock { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public short Status { get; set; }
        public int SourceOfOrigin { get; set; }
        public int OrganizationId { get; set; }
        [NotMapped]
        public double AvgPrice { get; set; }
        [NotMapped]
        public string SourceOfOriginName { get; set; }
        public int? ItemTypeId { get; set; }
    }
}