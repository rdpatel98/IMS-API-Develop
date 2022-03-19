using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSAPI.Models
{
    [Table("CityName")]
    public class City
    {
        [Key]
        public int CityID { get; set; }

        public byte RefStateID { get; set; }

        public string CityName { get; set; }

        public bool IsActive { get; set; }
    }
}