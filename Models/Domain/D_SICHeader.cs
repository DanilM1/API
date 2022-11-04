using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class D_SICHeader
    {
        [Key]
        public string sGroupCode { get; set; }

        [Required]
        public string sDescription { get; set; }

        public bool? isActive { get; set; }
    }
}