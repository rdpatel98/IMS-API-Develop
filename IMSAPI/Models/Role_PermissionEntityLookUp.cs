using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("Role_PermissionEntityLookUps")]
    public class Role_PermissionEntityLookUp
    {
        [Key]
        public int Id { get; set; }
        public PermissionEntityLookUp PermissionEntityLookUp { get; set; }
        public int PermissionEntityLookupId { get; set; }
        public AppRole Role { get; set; }
        public int RoleId { get; set; }
    }
}