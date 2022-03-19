using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("Addresses")]
    public class Addresses
    {
        [Key]
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public short Status { get; set; }
    }
}