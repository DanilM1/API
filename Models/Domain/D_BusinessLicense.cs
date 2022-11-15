using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class D_BusinessLicense
    {
        // step 1

        [Key]
        public int License_id { get; set; }

        public Guid vendorUser_Id { get; set; }

        public D_User vendor { get; set; }

        [Required]
        [MaxLength(200)]
        public string sBusinessname_Legal { get; set; }

        [Required]
        [MaxLength(200)]
        public string sName_First_Soleproprietor { get; set; }

        [MaxLength(5)]
        public string? sName_Mi_Soleproprietor { get; set; }

        [Required]
        [MaxLength(200)]
        public string sName_Last_Soleproprietor { get; set; }

        [MaxLength(200)]
        public string? sBusinessName_trade { get; set; }

        [Required]
        [MaxLength(12)]
        public string sFIDSSN { get; set; }

        [Required]
        [MaxLength(200)]
        public string sBusiness_Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string sBusiness_City { get; set; }

        [Required]
        [MaxLength(30)]
        public string sBusiness_State { get; set; }

        [Required]
        [MaxLength(5)]
        public string sBusiness_Zip { get; set; }

        [MaxLength(254)]
        public string? sMailing_Address { get; set; }

        [MaxLength(50)]
        public string? sMailing_City { get; set; }

        [MaxLength(30)]
        public string? sMailing_State { get; set; }

        [MaxLength(5)]
        public string? sMailing_Zip { get; set; }

        [Required]
        [MaxLength(14)]
        public string sPhoneNo_DayTime { get; set; }

        [MaxLength(14)]
        public string? sPhoneNo_Other { get; set; }

        [MaxLength(14)]
        public string? sFaxNo { get; set; }

        [Required]
        public DateTime applicationDate { get; set; }

        // step 2

        [MaxLength(200)]
        public string? sOPO1_Name { get; set; }

        [MaxLength(200)]
        public string? sOPO1_Title { get; set; }

        [MaxLength(14)]
        public string? sOPO1_BusinessPhone { get; set; }

        [MaxLength(14)]
        public string? sOPO1_HomePhone { get; set; }

        [MaxLength(200)]
        public string? sOPO1_HomeAddress { get; set; }

        [MaxLength(50)]
        public string? sOPO1_City { get; set; }

        [MaxLength(30)]
        public string? sOPO1_State { get; set; }

        [MaxLength(5)]
        public string? sOPO1_Zip { get; set; }

        [MaxLength(200)]
        public string? sOPO2_Name { get; set; }

        [MaxLength(200)]
        public string? sOPO2_Title { get; set; }

        [MaxLength(14)]
        public string? sOPO2_BusinessPhone { get; set; }

        [MaxLength(14)]
        public string? sOPO2_HomePhone { get; set; }

        [MaxLength(200)]
        public string? sOPO2_HomeAddress { get; set; }

        [MaxLength(50)]
        public string? sOPO2_City { get; set; }

        [MaxLength(30)]
        public string? sOPO2_State { get; set; }

        [MaxLength(5)]
        public string? sOPO2_Zip { get; set; }

        [MaxLength(200)]
        public string? sOPO3_Name { get; set; }

        [MaxLength(200)]
        public string? sOPO3_Title { get; set; }

        [MaxLength(14)]
        public string? sOPO3_BusinessPhone { get; set; }

        [MaxLength(14)]
        public string? sOPO3_HomePhone { get; set; }

        [MaxLength(200)]
        public string? sOPO3_HomeAddress { get; set; }

        [MaxLength(50)]
        public string? sOPO3_City { get; set; }

        [MaxLength(30)]
        public string? sOPO3_State { get; set; }

        [MaxLength(5)]
        public string? sOPO3_Zip { get; set; }

        // step 3

        [MaxLength(200)]
        public string? iType_LegalOrg { get; set; }

        public bool? bMember { get; set; }

        public float? iOwned_SWST_Percent { get; set; }

        public float? iOwned_AmeriIndian_percent { get; set; }

        [MaxLength(5)]
        public string? sGroupCode_1 { get; set; }

        public int? sSICCode_1 { get; set; }

        [MaxLength(5)]
        public string? sGroupCode_2 { get; set; }

        public int? sSICCode_2 { get; set; }

        [MaxLength(5)]
        public string? sGroupCode_3 { get; set; }

        public int? sSICCode_3 { get; set; }

        [MaxLength(5)]
        public string? sGroupCode_4 { get; set; }

        public int? sSICCode_4 { get; set; }

        public bool? ibusiness_located { get; set; }

        [MaxLength(200)]
        public string? directions_nearest_town { get; set; }

        // step 4

        [MaxLength(200)]
        public string? iReason_License { get; set; }

        [MaxLength(200)]
        public string? prior_owner_Name { get; set; }

        [MaxLength(200)]
        public string? prior_owner_Title { get; set; }

        [MaxLength(14)]
        public string? prior_owner_BusinessPhone { get; set; }

        [MaxLength(14)]
        public string? prior_owner_HomePhone { get; set; }

        [MaxLength(200)]
        public string? prior_owner_HomeAddress { get; set; }

        [MaxLength(50)]
        public string? prior_owner_City { get; set; }

        [MaxLength(30)]
        public string? prior_owner_State { get; set; }

        [MaxLength(5)]
        public string? prior_owner_Zip { get; set; }

        [MaxLength(200)]
        public string? sCTT_Id_Current { get; set; }

        public bool? bCTT_Id_Cancel { get; set; }

        public DateTime? dCTT_Id_CancelEff { get; set; }

        // step 5

        [MaxLength(8)]
        public string? sLicenseNo { get; set; }

        [MaxLength(24)]
        public string? sPwd { get; set; }

        [MaxLength(200)]
        public string? secretQuestion { get; set; }

        [MaxLength(200)]
        public string? secretAnswer { get; set; }

        [MaxLength(254)]
        public string? sEmail { get; set; }
    }
}