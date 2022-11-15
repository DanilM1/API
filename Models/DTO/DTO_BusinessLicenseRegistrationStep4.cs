namespace API.Models.DTO
{
    public class DTO_BusinessLicenseRegistrationStep4
    {
        public string iReason_License { get; set; }
        public string prior_owner_Name { get; set; }
        public string prior_owner_Title { get; set; }
        public string prior_owner_BusinessPhone { get; set; }
        public string prior_owner_HomePhone { get; set; }
        public string prior_owner_HomeAddress { get; set; }
        public string prior_owner_City { get; set; }
        public string prior_owner_State { get; set; }
        public string prior_owner_Zip { get; set; }
        public string sCTT_Id_Current { get; set; }
        public bool? bCTT_Id_Cancel { get; set; } = null;
        public DateTime? dCTT_Id_CancelEff { get; set; } = null;
    }
}