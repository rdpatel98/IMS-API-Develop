using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("PermissionEntityLookUps")]
    public class PermissionEntityLookUp
    {
        public PermissionEntityLookUp()
        {
            Role_PermissionEntityLookUps = new HashSet<Role_PermissionEntityLookUp>();
        }
        [Key]
        public int Id { get; set; }
        public PermissionEntity PermissionEntity { get; set; }
        public int PermissionEntityId { get; set; }
        public Lookup Lookup { get; set; }
        public int LookupId { get; set; }
        public ICollection<Role_PermissionEntityLookUp> Role_PermissionEntityLookUps { get; set; }
    }
}