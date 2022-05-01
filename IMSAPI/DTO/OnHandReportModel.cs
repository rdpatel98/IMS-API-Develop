using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.DTO
{
    public class OnHandReportListModel
    {
        public IEnumerable<OnHandReportModel> Reports { get; set; }
    }

    public class OnHandReportModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string OnHand { get; set; }
        public string ItemTypeId { get; set; }
    }
}