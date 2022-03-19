using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    public class ItemOnHandQty
    {
        public int ItemId { get; set; }
        public string ItemNo { get; set; }
        public string WarehouseName { get; set; }
        public string Unit { get; set; }
        public double OnHandQuantity { get; set; }
    }
}