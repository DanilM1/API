using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class D_ZipCode
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(6)]
        public string name { get; set; }

        public D_City city { get; set; }
    }
}