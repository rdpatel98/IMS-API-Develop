using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Dto.PermissionEntityLookUps
{
    public class PermissionEntityLookUpList
    {
        public int EntityId { get; set; }
        public string EntityName { get; set; }
        public string LookUpNames { get; set; }
    }
}