using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    public class SavePurchaseReceive
    {
        public PurchaseReceive PurchaseReceive { get; set; }

        public List<PurchaseReceiveItems> PurchaseReceiveItems { get; set; }
        public string InvoiceNumber { get; set; }
    }
}