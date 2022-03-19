using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("Transactions")]
    public class Transactions
    {
        [Key]
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public short Type { get; set; }
        public int RelationId { get; set; }
        public int OrganizationId { get; set; }
    }
}