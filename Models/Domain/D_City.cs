using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    [Keyless]
    public class D_City
    {
        [Required]
        public string City { get; set; }

        [Required]
        public string ZIP { get; set; }

        public D_State D_State { get; set; }
    }
}