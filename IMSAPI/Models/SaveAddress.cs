using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSAPI.Models
{
    public class SaveAddress
    {
        public int MasterId { get; set; }

        public List<Addresses> Addresses { get; set; }
    }
}