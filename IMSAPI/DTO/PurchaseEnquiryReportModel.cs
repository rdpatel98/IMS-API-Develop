using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.DTO
{
    public class PurchaseEnquiryReportListModel
    {
        public IQueryable<PurchaseEnquiryReportModel> Reports { get; set; }
    }

    public class PurchaseEnquiryReportModel
    {
        public string Date { get; set; }
        public string OrderNo { get; set; }
        public short Status { get; set; }
        public string VendorName { get; set; }
        public int VendorId { get; set; }
        public double Amount { get; set; }
        public int WarehouseId { get; set; }
    }
}