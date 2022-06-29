using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("ItemTypes")]
    public class ItemTypes
    {
        [Key]
        public int ItemTypeId { get; set; }
        public string Name { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public int? OrganizationId { get; set; }
    }
}