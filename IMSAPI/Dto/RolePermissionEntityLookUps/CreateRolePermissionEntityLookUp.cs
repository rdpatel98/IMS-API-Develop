using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Dto.RolePermissionEntityLookUps
{
    public class CreateRolePermissionEntityLookUp
    {
        public int PermissionEntityLookUpId { get; set; }
        public List<int> RoleIds { get; set; }
    }
}