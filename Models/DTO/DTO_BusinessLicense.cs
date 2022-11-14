using API.Models.Domain;

namespace API.Models.DTO
{
    public class DTO_BusinessLicense
    {
        public string vendor { get; set; }
        public string sLicenseNo { get; set; }
        public DateTime applicationDate { get; set; }
        public DateTime? dCTT_Id_CancelEff { get; set; }
        public string sName_First_Soleproprietor { get; set; }
        public string sName_Last_Soleproprietor { get; set; }
        public string sBusiness_Address { get; set; }
        public string sBusiness_City { get; set; }
        public string sBusiness_State { get; set; }
        public string sPhoneNo_DayTime { get; set; }
        public string sEmail { get; set; }
        public string sBusiness_Zip { get; set; }
        public string sMailing_Zip { get; set; }
    }
}