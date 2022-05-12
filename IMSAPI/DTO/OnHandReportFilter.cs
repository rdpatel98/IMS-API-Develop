using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.DTO
{
    public class OnHandReportFilter
    {
        public string ItemMaster { get; set; }
        public int WarehouseId { get; set; }
        public int? ItemType { get; set; }
        public int OrganizationId { get; set; }
    }

}