using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    [Table("UserOrganizations")]
    public class UserOrganization
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public int UserId { get; set; }
        public Organization Organization { get; set; }
        public int OrganizationId { get; set; }
    }
}