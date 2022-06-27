using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("ConsumptionItems")]
    public class ConsumptionItems
    {
        [Key]
        public int ConsumptionItemsId { get; set; }
        public int ConsumptionId { get; set; }
        public int ItemCategoryId { get; set; }
        public string LineNo { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public double Quantity { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        [NotMapped]
        public string ItemName { get; set; }
        [NotMapped]
        public string UnitName { get; set; }
        [NotMapped]
        public double OnHandQty { get; set; }
    }
}