using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("Consumption")]
    public class Consumption
    {
        [Key]
        public int ConsumptionId { get; set; }
        public string ConsumptionNo { get; set; }
        public DateTime ConsumptionDate { get; set; }
        public int WarehouseId { get; set; }
        public int WorkerId { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public short Status { get; set; }
        public int OrganizationId { get; set; }
    }
}