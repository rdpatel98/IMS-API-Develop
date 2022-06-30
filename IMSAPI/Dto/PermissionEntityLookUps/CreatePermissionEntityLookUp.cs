using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Dto.PermissionEntityLookUps
{
    public class CreatePermissionEntityLookUp
    {
        public int EntityId { get; set; }
        public List<int> LookUpIds { get; set; }
    }
}