using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("PurchaseOrder")]
    public class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderItems = new HashSet<PurchaseOrderItems>();
        }
        [Key]
        public int PurchaseOrderId { get; set; }
        public string PurchaseOrderNo { get; set; }
        public Vendor Vendor { get; set; }
        public int VendorId { get; set; }
        public double NetAmount { get; set; }
        public short OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public short Status { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<PurchaseOrderItems> PurchaseOrderItems { get; set; }
    }
}