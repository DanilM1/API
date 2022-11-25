using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Domain
{
    public class D_SICCode
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [MaxLength(200)]
        public string name { get; set; }

        public D_GroupOfSICCodes groupOfSICCodes { get; set; }
    }
}