using API.Models.Domain;

namespace API.Models.DTO
{
    public class DTO_BusinessLicenseRegistrationStep5
    {
        public D_User vendor { get; set; }
        public DateTime applicationDate { get; set; }
        public DateTime? dStartDate { get; set; } = null;
        public DateTime? dEndDate { get; set; } = null;
        public string sPwd { get; set; }
        public string secretQuestion { get; set; }
        public string secretAnswer { get; set; }
        public string sEmail { get; set; }
    }
}