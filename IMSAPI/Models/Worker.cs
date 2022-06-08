using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("Worker")]
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string PersonnelNumber { get; set; }
        public DateTime DOJ { get; set; }
        public DateTime DOB { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public short Status { get; set; }
        public bool IsBlocked { get; set; }
        public int OrganizationId { get; set; }
        public string UserMasterId { get; set; }

    }
}