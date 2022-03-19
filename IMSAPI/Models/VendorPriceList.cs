using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    public class VendorPriceList
    {
        public string VendorNo { get; set; }
        public string VendorName { get; set; }
        public double UnitPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}