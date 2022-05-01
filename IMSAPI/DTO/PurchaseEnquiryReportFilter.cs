﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.DTO
{
    public class PurchaseEnquiryReportFilter
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int? Status { get; set; }
        public int? WarehouseId { get; set; }
        public int? VendorId { get; set; }
        public int OrganizationId { get; set; }
    }
}