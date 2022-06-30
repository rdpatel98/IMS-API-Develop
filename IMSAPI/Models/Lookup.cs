using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("LookUps")]
    public class Lookup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PermissionName { get; set; }
    }
}