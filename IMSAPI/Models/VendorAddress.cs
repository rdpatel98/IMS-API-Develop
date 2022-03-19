using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("VendorAddress")]
    public class VendorAddress
    {
        [Key]
        public int VendorAddressId { get; set; }

        public int VendorId { get; set; }

        public int AddressId { get; set; }
    }
}