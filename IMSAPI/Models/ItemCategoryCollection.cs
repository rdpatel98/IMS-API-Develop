using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("ItemCategoryCollection")]
    public class ItemCategoryCollection
    {
        [Key]
        public int ItemCategoryCollectionId { get; set; }
        public int ItemCategoryId { get; set; }
        public int ItemId { get; set; }
        [NotMapped]
        public string ItemName { get; set; }
        [NotMapped]
        public string UnitName { get; set; }
        [NotMapped]
        public int UnitId { get; set; }
        [NotMapped]
        public double OnHandQty { get; set; }
        public int CategoryId { get; set; }
    }
}