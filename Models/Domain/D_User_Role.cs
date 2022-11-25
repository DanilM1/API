using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class D_User_Role
    {
        [Key]
        public int id { get; set; }

        [Required]
        public Guid user_id { get; set; }

        [Required]
        public D_User user { get; set; }

        [Required]
        public int role_id { get; set; }

        [Required]
        public D_Role role { get; set; }
    }
}