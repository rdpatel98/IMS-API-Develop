using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    public class SaveItemConsumption
    {
        public Consumption Consumption { get; set; }

        public List<ConsumptionItems> ConsumptionItems { get; set; }
    }

    public class SaveItemConsumptionWithCategory
    {
        public Consumption Consumption { get; set; }

        public List<ConsumptionCategory> ConsumptionCategory { get; set; }
    }

    public class ConsumptionCategory
    {
        public int ItemCategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ConsumptionItems> ConsumptionItems { get; set; }
    }
}