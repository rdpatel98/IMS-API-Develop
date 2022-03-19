using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    public class UserDetail
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int OrganizationId { get; set; }
        public int DefaultWarehouseId { get; set; }
    }
}