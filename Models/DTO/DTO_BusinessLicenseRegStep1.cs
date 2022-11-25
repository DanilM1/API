namespace API.Models.DTO
{
    public class DTO_BusinessLicenseRegStep1
    {
        public string businessName { get; set; }
        public string firstName { get; set; }
        public string middleInitial { get; set; }
        public string lastName { get; set; }
        public string businessTradeName { get; set; }
        public string ID_SSN { get; set; }
        public string businessAddress { get; set; }
        public int businessCityId { get; set; }
        public int businessStateId { get; set; }
        public int businessZipCodeId { get; set; }
        public string mailingAddress { get; set; }
        public int? mailingCityId { get; set; } = null;
        public int? mailingStateId { get; set; } = null;
        public int? mailingZipCodeId { get; set; } = null;
        public string dayTimePhone { get; set; }
        public string otherPhone { get; set; }
        public string fax { get; set; }
    }
}