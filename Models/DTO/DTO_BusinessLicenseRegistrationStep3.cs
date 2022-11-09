namespace API.Models.DTO
{
    public class DTO_BusinessLicenseRegistrationStep3
    {
        public string iType_LegalOrg { get; set; }
        public bool bMember { get; set; }
        public float? iOwned_SWST_Percent { get; set; } = null;
        public float? iOwned_AmeriIndian_percent { get; set; } = null;
        public string sGroupCode_1 { get; set; }
        public int? sSICCode_1 { get; set; } = null;
        public string sGroupCode_2 { get; set; }
        public int? sSICCode_2 { get; set; } = null;
        public string sGroupCode_3 { get; set; }
        public int? sSICCode_3 { get; set; } = null;
        public string sGroupCode_4 { get; set; }
        public int? sSICCode_4 { get; set; } = null;
        public bool? ibusiness_located { get; set; } = null;
        public string directions_nearest_town { get; set; }

        public int License_id { get; set; }
    }
}