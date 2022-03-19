using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("PurchaseReceiveItems")]
    public class PurchaseReceiveItems
    {
        [Key]
        public int PurchaseReceiveItemsId { get; set; }
        public int PurchaseReceiveId { get; set; }
        public short LineNo { get; set; }
        public int ItemId { get; set; }
        public int WarehouseId { get; set; }
        public double Quantity { get; set; }
        public double ReceiveQuantity { get; set; }
        public int UnitId { get; set; }
        public double UnitPrice { get; set; }
        public double NetAmount { get; set; }
        public string BatchNo { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}