using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.DTO
{
    public class ConsumptionReportModel
    {
        public List<ReportModel> Reports { get; set; }
        public List<ItemCategoryHeader> ItemCategories { get; set; }
    }

    public class ReportModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string OnHand { get; set; }
        public string ItemTypeId { get; set; }
        public string Worker { get; set; }
        public int TotalConsumptions { get; set; }
        public IEnumerable<ItemCategories> CategoryData { get; set; }
    }

    public class ItemCategories
    {
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public int ItemId { get; set; }
        public int ItemCategoryId { get; set; }
        public int CategoryId { get; set; }
    }
    public class ItemCategoryHeader
    {
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public int ItemCategoryId { get; set; }
    }
}