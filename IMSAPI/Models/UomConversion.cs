using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("UomConversion")]
    public class UomConversion
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }        
        public string Description { get; set; }
        public int FromUnitId { get; set; }
        [NotMapped]
        public string FromUnit { get; set; }
        public int ToUnitId { get; set; }
        [NotMapped]
        public string ToUnit { get; set; }
        public double Ratio { get; set; }
        public int OrganizationId { get; set; }
    }
}