using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    public class SaveInventoryAdjustment
    {
        public InventoryAdjustment InventoryAdjustment { get; set; }

        public List<InventoryAdjustmentItems> InventoryAdjustmentItems { get; set; }
    }
}