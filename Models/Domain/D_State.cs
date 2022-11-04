using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class D_State
    {
        [Required]
        public string Country_id { get; set; }

        [Key]
        public string State_id { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZIPs { get; set; }

        [Required]
        public string StateCapital { get; set; }
    }
}