using API.Data;
using API.Models.Domain;
using API.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class R_BusinessLicense : I_BusinessLicense
    {
        private readonly APIDbContext APIDbContext;

        public R_BusinessLicense(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<int> GetCountOfAllLicenses()
        {
            return await APIDbContext.BusinessLicenses.CountAsync();
        }

        public async Task<int> GetCountOfAllLicensesWithOnlyMembers()
        {
            return await APIDbContext.BusinessLicenses.Where(x => x.bMember == true).CountAsync();
        }

        public async Task<int?> GetMaxIdOfLicense_Filter_Vendor(Guid vendorUser_Id)
        {
            return await APIDbContext.BusinessLicenses.Where(x => x.vendorUser_Id == vendorUser_Id).Select(x => x.License_id).MaxAsync();
        }

        public async Task<D_BusinessLicense> GetLicense_Filter_LisenseId(int? License_id)
        {
            return await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.License_id == License_id);
        }

        public async Task<IEnumerable<DTO_BusinessLicense>> GetListOfAllLicenses()
        {
            var query = from BusinessLicenses in APIDbContext.BusinessLicenses
                        join Users in APIDbContext.Users on BusinessLicenses.vendorUser_Id equals Users.User_id
                        select new
                        {
                            Users.Username,
                            BusinessLicenses.sLicenseNo,
                            BusinessLicenses.applicationDate,
                            BusinessLicenses.dCTT_Id_CancelEff,
                            BusinessLicenses.sName_First_Soleproprietor,
                            BusinessLicenses.sName_Last_Soleproprietor,
                            BusinessLicenses.sBusiness_Address,
                            BusinessLicenses.sBusiness_City,
                            BusinessLicenses.sBusiness_State,
                            BusinessLicenses.sPhoneNo_DayTime,
                            BusinessLicenses.sEmail,
                            BusinessLicenses.sBusiness_Zip,
                            BusinessLicenses.sMailing_Zip
                        };

            var list = await query.ToListAsync().ConfigureAwait(false);

            return list.Select(x => new DTO_BusinessLicense()
            {
                vendor = x.Username,
                sLicenseNo = x.sLicenseNo,
                applicationDate = x.applicationDate,
                dCTT_Id_CancelEff = x.dCTT_Id_CancelEff,
                sName_First_Soleproprietor = x.sName_First_Soleproprietor,
                sName_Last_Soleproprietor = x.sName_Last_Soleproprietor,
                sBusiness_Address = x.sBusiness_Address,
                sBusiness_City = x.sBusiness_City,
                sBusiness_State = x.sBusiness_State,
                sPhoneNo_DayTime = x.sPhoneNo_DayTime,
                sEmail = x.sEmail,
                sBusiness_Zip = x.sBusiness_Zip,
                sMailing_Zip = x.sMailing_Zip
            }).ToList();
        }

        public async Task<IEnumerable<DTO_BusinessLicense>> GetListOfAllLicenses_Filter_Dates(DateTime applicationDate, DateTime dCTT_Id_CancelEff)
        {
            var query = from BusinessLicenses in APIDbContext.BusinessLicenses
                        join Users in APIDbContext.Users on BusinessLicenses.vendorUser_Id equals Users.User_id
                        where BusinessLicenses.applicationDate >= applicationDate && BusinessLicenses.dCTT_Id_CancelEff <= dCTT_Id_CancelEff
                        select new
                        {
                            Users.Username,
                            BusinessLicenses.sLicenseNo,
                            BusinessLicenses.applicationDate,
                            BusinessLicenses.dCTT_Id_CancelEff,
                            BusinessLicenses.sName_First_Soleproprietor,
                            BusinessLicenses.sName_Last_Soleproprietor,
                            BusinessLicenses.sBusiness_Address,
                            BusinessLicenses.sBusiness_City,
                            BusinessLicenses.sBusiness_State,
                            BusinessLicenses.sPhoneNo_DayTime,
                            BusinessLicenses.sEmail,
                            BusinessLicenses.sBusiness_Zip,
                            BusinessLicenses.sMailing_Zip
                        };

            var list = await query.ToListAsync().ConfigureAwait(false);

            return list.Select(x => new DTO_BusinessLicense()
            {
                vendor = x.Username,
                sLicenseNo = x.sLicenseNo,
                applicationDate = x.applicationDate,
                dCTT_Id_CancelEff = x.dCTT_Id_CancelEff,
                sName_First_Soleproprietor = x.sName_First_Soleproprietor,
                sName_Last_Soleproprietor = x.sName_Last_Soleproprietor,
                sBusiness_Address = x.sBusiness_Address,
                sBusiness_City = x.sBusiness_City,
                sBusiness_State = x.sBusiness_State,
                sPhoneNo_DayTime = x.sPhoneNo_DayTime,
                sEmail = x.sEmail,
                sBusiness_Zip = x.sBusiness_Zip,
                sMailing_Zip = x.sMailing_Zip
            }).ToList();
        }

        public async Task<IEnumerable<DTO_BusinessLicense>> GetListOfAllLicenses_Filter_SICs(string sGroupCode, int sSICCode)
        {
            var query = from BusinessLicenses in APIDbContext.BusinessLicenses
                        join Users in APIDbContext.Users on BusinessLicenses.vendorUser_Id equals Users.User_id
                        where
                            BusinessLicenses.sGroupCode_1 == sGroupCode && BusinessLicenses.sSICCode_1 == sSICCode ||
                            BusinessLicenses.sGroupCode_2 == sGroupCode && BusinessLicenses.sSICCode_2 == sSICCode ||
                            BusinessLicenses.sGroupCode_3 == sGroupCode && BusinessLicenses.sSICCode_3 == sSICCode ||
                            BusinessLicenses.sGroupCode_4 == sGroupCode && BusinessLicenses.sSICCode_4 == sSICCode
                        select new
                        {
                            Users.Username,
                            BusinessLicenses.sLicenseNo,
                            BusinessLicenses.applicationDate,
                            BusinessLicenses.dCTT_Id_CancelEff,
                            BusinessLicenses.sName_First_Soleproprietor,
                            BusinessLicenses.sName_Last_Soleproprietor,
                            BusinessLicenses.sBusiness_Address,
                            BusinessLicenses.sBusiness_City,
                            BusinessLicenses.sBusiness_State,
                            BusinessLicenses.sPhoneNo_DayTime,
                            BusinessLicenses.sEmail,
                            BusinessLicenses.sBusiness_Zip,
                            BusinessLicenses.sMailing_Zip
                        };

            var list = await query.ToListAsync().ConfigureAwait(false);

            return list.Select(x => new DTO_BusinessLicense()
            {
                vendor = x.Username,
                sLicenseNo = x.sLicenseNo,
                applicationDate = x.applicationDate,
                dCTT_Id_CancelEff = x.dCTT_Id_CancelEff,
                sName_First_Soleproprietor = x.sName_First_Soleproprietor,
                sName_Last_Soleproprietor = x.sName_Last_Soleproprietor,
                sBusiness_Address = x.sBusiness_Address,
                sBusiness_City = x.sBusiness_City,
                sBusiness_State = x.sBusiness_State,
                sPhoneNo_DayTime = x.sPhoneNo_DayTime,
                sEmail = x.sEmail,
                sBusiness_Zip = x.sBusiness_Zip,
                sMailing_Zip = x.sMailing_Zip
            }).ToList();
        }

        public async Task<string> AddNewLicense(D_BusinessLicense License)
        {
            await APIDbContext.BusinessLicenses.AddAsync(License);
            await APIDbContext.SaveChangesAsync();
            return "1 step was success";
        }

        public async Task<string> UpdateLicenseByIdStep2(int? License_id, D_BusinessLicense License)
        {
            var buf = await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.License_id == License_id);

            if (buf == null) return null;

            buf.sOPO1_Name = License.sOPO1_Name;
            buf.sOPO1_Title = License.sOPO1_Title;
            buf.sOPO1_BusinessPhone = License.sOPO1_BusinessPhone;
            buf.sOPO1_HomePhone = License.sOPO1_HomePhone;
            buf.sOPO1_HomeAddress = License.sOPO1_HomeAddress;
            buf.sOPO1_City = License.sOPO1_City;
            buf.sOPO1_State = License.sOPO1_State;
            buf.sOPO1_Zip = License.sOPO1_Zip;

            buf.sOPO2_Name = License.sOPO2_Name;
            buf.sOPO2_Title = License.sOPO2_Title;
            buf.sOPO2_BusinessPhone = License.sOPO2_BusinessPhone;
            buf.sOPO2_HomePhone = License.sOPO2_HomePhone;
            buf.sOPO2_HomeAddress = License.sOPO2_HomeAddress;
            buf.sOPO2_City = License.sOPO2_City;
            buf.sOPO2_State = License.sOPO2_State;
            buf.sOPO2_Zip = License.sOPO2_Zip;

            buf.sOPO3_Name = License.sOPO3_Name;
            buf.sOPO3_Title = License.sOPO3_Title;
            buf.sOPO3_BusinessPhone = License.sOPO3_BusinessPhone;
            buf.sOPO3_HomePhone = License.sOPO3_HomePhone;
            buf.sOPO3_HomeAddress = License.sOPO3_HomeAddress;
            buf.sOPO3_City = License.sOPO3_City;
            buf.sOPO3_State = License.sOPO3_State;
            buf.sOPO3_Zip = License.sOPO3_Zip;

            await APIDbContext.SaveChangesAsync();
            return "2 step was success";
        }

        public async Task<string> UpdateLicenseByIdStep3(int? License_id, D_BusinessLicense License)
        {
            var buf = await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.License_id == License_id);

            if (buf == null) return null;

            buf.iType_LegalOrg = License.iType_LegalOrg;
            buf.bMember = License.bMember;
            buf.iOwned_SWST_Percent = License.iOwned_SWST_Percent;
            buf.iOwned_AmeriIndian_percent = License.iOwned_AmeriIndian_percent;
            buf.sGroupCode_1 = License.sGroupCode_1;
            buf.sSICCode_1 = License.sSICCode_1;
            buf.sGroupCode_2 = License.sGroupCode_2;
            buf.sSICCode_2 = License.sSICCode_2;
            buf.sGroupCode_3 = License.sGroupCode_3;
            buf.sSICCode_3 = License.sSICCode_3;
            buf.sGroupCode_4 = License.sGroupCode_4;
            buf.sSICCode_4 = License.sSICCode_4;
            buf.ibusiness_located = License.ibusiness_located;
            buf.directions_nearest_town = License.directions_nearest_town;

            await APIDbContext.SaveChangesAsync();
            return "3 step was success";
        }

        public async Task<string> UpdateLicenseByIdStep4(int? License_id, D_BusinessLicense License)
        {
            var buf = await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.License_id == License_id);

            if (buf == null) return null;

            buf.iReason_License = License.iReason_License;
            buf.prior_owner_Name = License.prior_owner_Name;
            buf.prior_owner_Title = License.prior_owner_Title;
            buf.prior_owner_BusinessPhone = License.prior_owner_BusinessPhone;
            buf.prior_owner_HomePhone = License.prior_owner_HomePhone;
            buf.prior_owner_HomeAddress = License.prior_owner_HomeAddress;
            buf.prior_owner_City = License.prior_owner_City;
            buf.prior_owner_State = License.prior_owner_State;
            buf.prior_owner_Zip = License.prior_owner_Zip;
            buf.sCTT_Id_Current = License.sCTT_Id_Current;
            buf.bCTT_Id_Cancel = License.bCTT_Id_Cancel;
            buf.dCTT_Id_CancelEff = License.dCTT_Id_CancelEff;

            await APIDbContext.SaveChangesAsync();
            return "4 step was success";
        }
        public async Task<string> UpdateLicenseByIdStep5(int? License_id, D_BusinessLicense License)
        {
            var buf = await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.License_id == License_id);

            if (buf == null) return null;

            buf.applicationDate = License.applicationDate;
            buf.sLicenseNo = License.sLicenseNo;
            buf.sPwd = License.sPwd;
            buf.secretQuestion = License.secretQuestion;
            buf.secretAnswer = License.secretAnswer;
            buf.sEmail = License.sEmail;

            await APIDbContext.SaveChangesAsync();
            return "5 step was success";
        }
    }
}