using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Dto.Roles
{
    public class CreateRole
    {
        public string Name { get; set; }
        public int OrganizationId { get; set; }
    }
}