using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Dto.RolePermissionEntityLookUps
{
    public class SaveRolePermissionRequest
    {
        public int RoleId { get; set; }
        public List<int> PermissionEntityLookUps { get; set; }
    }
    public enum SaveRolePermissionResult
    {
        Success = 1,
        Failed = 2
    }
}