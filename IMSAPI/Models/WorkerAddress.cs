using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("WorkerAddress")]
    public class WorkerAddress
    {
        [Key]
        public int WorkerAddressId { get; set; }

        public int WorkerId { get; set; }

        public int AddressId { get; set; }
    }
}