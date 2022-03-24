using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("Warehouse")]
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }
        [StringLength(10)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int OrganizationId { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public short Status { get; set; }
    }
}