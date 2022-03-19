using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("ItemCategory")]
    public class ItemCategory
    {
        [Key]
        public int ItemCategoryId { get; set; }
        public int CategoryId { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public short Status { get; set; }
        public int OrganizationId { get; set; }
    }
}