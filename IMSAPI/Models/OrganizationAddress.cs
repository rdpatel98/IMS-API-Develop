using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("OrganizationAddress")]
    public class OrganizationAddress
    {
        [Key]
        public int OrganizationAddressId { get; set; }

        public int OrganizationId { get; set; }

        public int AddressId { get; set; }
    }
}