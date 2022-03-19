using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("Vendor")]
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public short Status { get; set; }
        public int OrganizationId { get; set; }
    }
}