namespace API.Models.DTO
{
    public class DTO_BusinessLicenseRegistrationStep1
    {
        public Guid vendorUser_Id { get; set; }
        public string sBusinessname_Legal { get; set; }
        public string sName_First_Soleproprietor { get; set; }
        public string sName_Mi_Soleproprietor { get; set; }
        public string sName_Last_Soleproprietor { get; set; }
        public string sBusinessName_trade { get; set; }
        public string sFIDSSN { get; set; }
        public string sBusiness_Address { get; set; }
        public string sBusiness_City { get; set; }
        public string sBusiness_State { get; set; }
        public string sBusiness_Zip { get; set; }
        public string sMailing_Address { get; set; }
        public string sMailing_City { get; set; }
        public string sMailing_State { get; set; }
        public string sMailing_Zip { get; set; }
        public string sPhoneNo_DayTime { get; set; }
        public string sPhoneNo_Other { get; set; }
        public string sFaxNo { get; set; }
    }
}