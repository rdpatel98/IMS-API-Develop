using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public short Status { get; set; }
        public int OrganizationId { get; set; }
    }
}