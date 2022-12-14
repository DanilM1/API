using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class D_Role
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(30)]
        public string name { get; set; }

        public List<D_User_Role> users_roles { get; set; }
    }
}