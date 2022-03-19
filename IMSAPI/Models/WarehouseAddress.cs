using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("WarehouseAddress")]
    public class WarehouseAddress
    {
        [Key]
        public int WarehouseAddressId { get; set; }

        public int WarehouseId { get; set; }

        public int AddressId { get; set; }
    }
}