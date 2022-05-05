using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.DTO
{
    public class ConsumptionReportModel
    {
        public List<ReportModel> Reports { get; set; }
        public List<string> ItemCategories { get; set; }
    }

    public class ReportModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string OnHand { get; set; }
        public string ItemTypeId { get; set; }
        public string Worker { get; set; }
        public List<string> CategoryData { get; set; }
    }

    public class ItemCategories
    {
        public string CategoryData { get; set; }
    }
}