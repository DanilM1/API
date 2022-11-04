using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    [Keyless]
    public class D_SIC
    {
        [Required]
        public int sSICCode { get; set; }

        [Required]
        public string sSICDescription { get; set; }

        public string? mReturnRate { get; set; }

        public byte? bRateIndicator { get; set; }

        public byte? bAcceptForm { get; set; }

        public bool? isActive { get; set; }

        public D_SICHeader D_SICHeader { get; set; }
    }
}