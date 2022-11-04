using API.Data;
using API.Models.Domain;
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

        public async Task<IEnumerable<D_BusinessLicense>> GetAllAsync()
        {
            return await APIDbContext.BusinessLicenses.ToListAsync();
        }

        public async Task<int> GetAsync()
        {
            return await APIDbContext.BusinessLicenses.MaxAsync(x => x.iTemp_id);
        }

        public async Task<D_BusinessLicense> GetMemberAsync(int iTemp_id)
        {
            return await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.iTemp_id == iTemp_id);
        }

        public async Task<int> GetMembersAsync()
        {
            return await APIDbContext.BusinessLicenses.Where(x => x.bMember == true).CountAsync();
        }

        public async Task<int> GetAllCountAsync()
        {
            return await APIDbContext.BusinessLicenses.CountAsync();
        }

        public async Task<IEnumerable<D_BusinessLicense>> GetAllDatesAsync(DateTime dStartDate, DateTime dEndDate)
        {
            return await APIDbContext.BusinessLicenses.Where(x => x.dStartDate >= dStartDate && x.dEndDate <= dEndDate).ToListAsync();
        }

        public async Task<IEnumerable<D_BusinessLicense>> GetAllSICsAsync(string sGroupCode, int sSICCode)
        {
            return await APIDbContext.BusinessLicenses.Where(x =>
                x.sGroupCode_1 == sGroupCode && x.sSICCode_1 == sSICCode ||
                x.sGroupCode_2 == sGroupCode && x.sSICCode_2 == sSICCode ||
                x.sGroupCode_3 == sGroupCode && x.sSICCode_3 == sSICCode ||
                x.sGroupCode_4 == sGroupCode && x.sSICCode_4 == sSICCode
            ).ToListAsync();
        }

        public async Task<string> AddAsync(D_BusinessLicense D_BusinessLicense)
        {
            await APIDbContext.BusinessLicenses.AddAsync(D_BusinessLicense);
            await APIDbContext.SaveChangesAsync();
            return "1 step was success";
        }

        public async Task<string> UpdateAsync2(int iTemp_id, D_BusinessLicense D_BusinessLicense)
        {
            var buf = await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.iTemp_id == iTemp_id);

            if (buf == null) return null;

            buf.sOPO1_Name = D_BusinessLicense.sOPO1_Name;
            buf.sOPO1_Title = D_BusinessLicense.sOPO1_Title;
            buf.sOPO1_BusinessPhone = D_BusinessLicense.sOPO1_BusinessPhone;
            buf.sOPO1_HomePhone = D_BusinessLicense.sOPO1_HomePhone;
            buf.sOPO1_HomeAddress = D_BusinessLicense.sOPO1_HomeAddress;
            buf.sOPO1_City = D_BusinessLicense.sOPO1_City;
            buf.sOPO1_State = D_BusinessLicense.sOPO1_State;
            buf.sOPO1_Zip = D_BusinessLicense.sOPO1_Zip;

            buf.sOPO2_Name = D_BusinessLicense.sOPO2_Name;
            buf.sOPO2_Title = D_BusinessLicense.sOPO2_Title;
            buf.sOPO2_BusinessPhone = D_BusinessLicense.sOPO2_BusinessPhone;
            buf.sOPO2_HomePhone = D_BusinessLicense.sOPO2_HomePhone;
            buf.sOPO2_HomeAddress = D_BusinessLicense.sOPO2_HomeAddress;
            buf.sOPO2_City = D_BusinessLicense.sOPO2_City;
            buf.sOPO2_State = D_BusinessLicense.sOPO2_State;
            buf.sOPO2_Zip = D_BusinessLicense.sOPO2_Zip;

            buf.sOPO3_Name = D_BusinessLicense.sOPO3_Name;
            buf.sOPO3_Title = D_BusinessLicense.sOPO3_Title;
            buf.sOPO3_BusinessPhone = D_BusinessLicense.sOPO3_BusinessPhone;
            buf.sOPO3_HomePhone = D_BusinessLicense.sOPO3_HomePhone;
            buf.sOPO3_HomeAddress = D_BusinessLicense.sOPO3_HomeAddress;
            buf.sOPO3_City = D_BusinessLicense.sOPO3_City;
            buf.sOPO3_State = D_BusinessLicense.sOPO3_State;
            buf.sOPO3_Zip = D_BusinessLicense.sOPO3_Zip;

            await APIDbContext.SaveChangesAsync();
            return "2 step was success";
        }

        public async Task<string> UpdateAsync3(int iTemp_id, D_BusinessLicense D_BusinessLicense)
        {
            var buf = await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.iTemp_id == iTemp_id);

            if (buf == null) return null;

            buf.iType_LegalOrg = D_BusinessLicense.iType_LegalOrg;
            buf.bMember = D_BusinessLicense.bMember;
            buf.iOwned_SWST_Percent = D_BusinessLicense.iOwned_SWST_Percent;
            buf.iOwned_AmeriIndian_percent = D_BusinessLicense.iOwned_AmeriIndian_percent;
            buf.sGroupCode_1 = D_BusinessLicense.sGroupCode_1;
            buf.sSICCode_1 = D_BusinessLicense.sSICCode_1;
            buf.sGroupCode_2 = D_BusinessLicense.sGroupCode_2;
            buf.sSICCode_2 = D_BusinessLicense.sSICCode_2;
            buf.sGroupCode_3 = D_BusinessLicense.sGroupCode_3;
            buf.sSICCode_3 = D_BusinessLicense.sSICCode_3;
            buf.sGroupCode_4 = D_BusinessLicense.sGroupCode_4;
            buf.sSICCode_4 = D_BusinessLicense.sSICCode_4;
            buf.ibusiness_located = D_BusinessLicense.ibusiness_located;
            buf.directions_nearest_town = D_BusinessLicense.directions_nearest_town;

            await APIDbContext.SaveChangesAsync();
            return "3 step was success";
        }

        public async Task<string> UpdateAsync4(int iTemp_id, D_BusinessLicense D_BusinessLicense)
        {
            var buf = await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.iTemp_id == iTemp_id);

            if (buf == null) return null;

            buf.iReason_License = D_BusinessLicense.iReason_License;
            buf.prior_owner_Name = D_BusinessLicense.prior_owner_Name;
            buf.prior_owner_Title = D_BusinessLicense.prior_owner_Title;
            buf.prior_owner_BusinessPhone = D_BusinessLicense.prior_owner_BusinessPhone;
            buf.prior_owner_HomePhone = D_BusinessLicense.prior_owner_HomePhone;
            buf.prior_owner_HomeAddress = D_BusinessLicense.prior_owner_HomeAddress;
            buf.prior_owner_City = D_BusinessLicense.prior_owner_City;
            buf.prior_owner_State = D_BusinessLicense.prior_owner_State;
            buf.prior_owner_Zip = D_BusinessLicense.prior_owner_Zip;
            buf.sCTT_Id_Current = D_BusinessLicense.sCTT_Id_Current;
            buf.bCTT_Id_Cancel = D_BusinessLicense.bCTT_Id_Cancel;
            buf.dCTT_Id_CancelEff = D_BusinessLicense.dCTT_Id_CancelEff;

            await APIDbContext.SaveChangesAsync();
            return "4 step was success";
        }

        public async Task<string> UpdateAsync5(int iTemp_id, D_BusinessLicense D_BusinessLicense)
        {
            var buf = await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.iTemp_id == iTemp_id);

            if (buf == null) return null;

            buf.vendor = D_BusinessLicense.vendor;
            buf.applicationDate = D_BusinessLicense.applicationDate;
            buf.sLicenseNo = D_BusinessLicense.sLicenseNo;
            buf.dStartDate = D_BusinessLicense.dStartDate;
            buf.dEndDate = D_BusinessLicense.dEndDate;
            buf.sPwd = D_BusinessLicense.sPwd;
            buf.secretQuestion = D_BusinessLicense.secretQuestion;
            buf.secretAnswer = D_BusinessLicense.secretAnswer;
            buf.sEmail = D_BusinessLicense.sEmail;

            await APIDbContext.SaveChangesAsync();
            return "5 step was success";
        }
    }
}