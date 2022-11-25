using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Domain
{
    public class D_User
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Required]
        [MaxLength(254)]
        public string email { get; set; }

        [Required]
        [MaxLength(24)]
        public string password { get; set; }

        [Required]
        [MaxLength(50)]
        public string firstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string lastName { get; set; }

        [NotMapped]
        public List<string> roles { get; set; }

        public List<D_User_Role> users_roles { get; set; }
    }
}