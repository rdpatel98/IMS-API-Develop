using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    public class SaveWorker
    {
        public CreateWorkerDto Worker { get; set; }

        public List<Addresses> Addresses { get; set; }
    }
    public class CreateWorkerDto
    {
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
        public List<int> OrganizationIds { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
    }
}