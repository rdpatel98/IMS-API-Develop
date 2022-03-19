using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("PurchaseReceive")]
    public class PurchaseReceive
    {
        [Key]
        public int PurchaseReceiveId { get; set; }
        public string PurchaseReceiveNo { get; set; }
        public int PurchaseOrderId { get; set; }
        public int VendorId { get; set; }
        public double NetAmount { get; set; }
        public short PurchaseReceiveStatus { get; set; }
        public DateTime PurchaseReceiveDate { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public short Status { get; set; }
        public int OrganizationId { get; set; }
    }
}