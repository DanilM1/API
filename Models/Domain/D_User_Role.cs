using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class D_User_Role
    {
        [Key]
        public int User_Role_id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public D_User D_User { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public D_Role D_Role { get; set; }
    }
}