using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        public int ItemId { get; set; }
        public int WarehouseId { get; set; }
        public int WorkerId { get; set; }
        public double Quantity { get; set; }
        public double OnHandQuantity { get; set; }
        public int TransactionId { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public short Status { get; set; }
    }
}