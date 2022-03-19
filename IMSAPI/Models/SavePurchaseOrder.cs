using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    public class SavePurchaseOrder
    {
        public PurchaseOrder PurchaseOrder { get; set; }

        public List<PurchaseOrderItems> PurchaseOrderItems { get; set; }

        public bool IsPurchaseReceiveSaved { get; set; }
    }
}