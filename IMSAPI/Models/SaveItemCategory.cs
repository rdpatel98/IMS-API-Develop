using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    public class SaveItemCategory
    {
        public ItemCategory ItemCategory { get; set; }

        public List<ItemCategoryCollection> ItemCategoryCollections { get; set; }
    }
}