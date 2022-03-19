using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public string InvoiceNo { get; set; }
        public int PurchaseOrderId { get; set; }
        public int VendorId { get; set; }
        public double NetAmount { get; set; }
        public short InvoiceStatus { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public short Status { get; set; }
        public int OrganizationId { get; set; }
    }
}