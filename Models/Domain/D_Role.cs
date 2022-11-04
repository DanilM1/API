using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class D_Role
    {
        [Key]
        public int Role_id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<D_User_Role> Users_Roles { get; set; }
    }
}