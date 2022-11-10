namespace API.Models.DTO
{
    public class DTO_BusinessLicenseRegistrationStep5
    {
        public string sPwd { get; set; }
        public string secretQuestion { get; set; }
        public string secretAnswer { get; set; }
        public string sEmail { get; set; }

        public Guid vendorUser_Id { get; set; }
        public int License_id { get; set; }
        public bool bMember { get; set; }
    }
}