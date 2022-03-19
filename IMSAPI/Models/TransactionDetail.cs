using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    public class TransactionDetail
    {
        public string ItemNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Reference { get; set; }
        public string RefNo { get; set; }
        public double Quantity { get; set; }
        public string LotNo { get; set; }
    }
}