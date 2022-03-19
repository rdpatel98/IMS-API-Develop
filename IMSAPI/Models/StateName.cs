using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSAPI.Models
{
    [Table("StateName")]
    public class State
    {
        [Key]
        public byte StateID { get; set; }

        public string StateName { get; set; }

        public bool IsActive { get; set; }
    }
}