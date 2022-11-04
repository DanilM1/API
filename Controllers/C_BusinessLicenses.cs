using API.Data;
using API.Models.Domain;
using API.Models.DTO;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_BusinessLicenses : Controller
    {
        private readonly APIDbContext APIDbContext;
        private readonly I_BusinessLicense obj;
        private readonly IMapper mapper;

        public C_BusinessLicenses(APIDbContext APIDbContext, I_BusinessLicense obj, IMapper mapper)
        {
            this.APIDbContext = APIDbContext;
            this.obj = obj;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        [ActionName("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(mapper.Map<List<DTO_BusinessLicense>>(await obj.GetAllAsync()));
        }

        [HttpGet]
        [Route("~/C_BusinessLicenses/Dates")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllDatesAsync(DateTime dStartDate, DateTime dEndDate)
        {
            return Ok(mapper.Map<List<DTO_BusinessLicense>>(await obj.GetAllDatesAsync(dStartDate, dEndDate)));
        }

        [HttpGet]
        [Route("~/C_BusinessLicenses/SICs")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllSICsAsync(string sGroupCode, int sSICCode)
        {
            return Ok(mapper.Map<List<DTO_BusinessLicense>>(await obj.GetAllSICsAsync(sGroupCode, sSICCode)));
        }

        [HttpPost]
        [Route("~/C_BusinessLicenses/BusinessLicenseRegistrationStep1")]
        [Authorize(Roles = "vendor")]
        public async Task<IActionResult> AddAsync(DTO_BusinessLicenseRegistrationStep1 BusinessLicenseRegistrationStep1)
        {
            if (!await ValidateAddAsync(BusinessLicenseRegistrationStep1)) return BadRequest(ModelState);

            var buf = new D_BusinessLicense()
            {
                sBusinessname_Legal = BusinessLicenseRegistrationStep1.sBusinessname_Legal,
                sName_First_Soleproprietor = BusinessLicenseRegistrationStep1.sName_First_Soleproprietor,
                sName_Mi_Soleproprietor = BusinessLicenseRegistrationStep1.sName_Mi_Soleproprietor,
                sName_Last_Soleproprietor = BusinessLicenseRegistrationStep1.sName_Last_Soleproprietor,
                sBusinessName_trade = BusinessLicenseRegistrationStep1.sBusinessName_trade,
                sFIDSSN = BusinessLicenseRegistrationStep1.sFIDSSN,
                sBusiness_Address = BusinessLicenseRegistrationStep1.sBusiness_Address,
                sBusiness_City = BusinessLicenseRegistrationStep1.sBusiness_City,
                sBusiness_State = BusinessLicenseRegistrationStep1.sBusiness_State,
                sBusiness_Zip = BusinessLicenseRegistrationStep1.sBusiness_Zip,
                sMailing_Address = BusinessLicenseRegistrationStep1.sMailing_Address,
                sMailing_City = BusinessLicenseRegistrationStep1.sMailing_City,
                sMailing_State = BusinessLicenseRegistrationStep1.sMailing_State,
                sMailing_Zip = BusinessLicenseRegistrationStep1.sMailing_Zip,
                sPhoneNo_DayTime = BusinessLicenseRegistrationStep1.sPhoneNo_DayTime,
                sPhoneNo_Other = BusinessLicenseRegistrationStep1.sPhoneNo_Other,
                sFaxNo = BusinessLicenseRegistrationStep1.sFaxNo
            };

            return Ok(await obj.AddAsync(buf));
        }

        [HttpPut]
        [Route("~/C_BusinessLicenses/BusinessLicenseRegistrationStep2")]
        [Authorize(Roles = "vendor")]
        public async Task<IActionResult> UpdateAsync2(int id, [FromBody] DTO_BusinessLicenseRegistrationStep2 BusinessLicenseRegistrationStep2)
        {
            if (!await ValidateUpdateAsync2(BusinessLicenseRegistrationStep2)) return BadRequest(ModelState);

            var buf = new D_BusinessLicense()
            {
                sOPO1_Name = BusinessLicenseRegistrationStep2.sOPO1_Name,
                sOPO1_Title = BusinessLicenseRegistrationStep2.sOPO1_Title,
                sOPO1_BusinessPhone = BusinessLicenseRegistrationStep2.sOPO1_BusinessPhone,
                sOPO1_HomePhone = BusinessLicenseRegistrationStep2.sOPO1_HomePhone,
                sOPO1_HomeAddress = BusinessLicenseRegistrationStep2.sOPO1_HomeAddress,
                sOPO1_City = BusinessLicenseRegistrationStep2.sOPO1_City,
                sOPO1_State = BusinessLicenseRegistrationStep2.sOPO1_State,
                sOPO1_Zip = BusinessLicenseRegistrationStep2.sOPO1_Zip,

                sOPO2_Name = BusinessLicenseRegistrationStep2.sOPO2_Name,
                sOPO2_Title = BusinessLicenseRegistrationStep2.sOPO2_Title,
                sOPO2_BusinessPhone = BusinessLicenseRegistrationStep2.sOPO2_BusinessPhone,
                sOPO2_HomePhone = BusinessLicenseRegistrationStep2.sOPO2_HomePhone,
                sOPO2_HomeAddress = BusinessLicenseRegistrationStep2.sOPO2_HomeAddress,
                sOPO2_City = BusinessLicenseRegistrationStep2.sOPO2_City,
                sOPO2_State = BusinessLicenseRegistrationStep2.sOPO2_State,
                sOPO2_Zip = BusinessLicenseRegistrationStep2.sOPO2_Zip,

                sOPO3_Name = BusinessLicenseRegistrationStep2.sOPO3_Name,
                sOPO3_Title = BusinessLicenseRegistrationStep2.sOPO3_Title,
                sOPO3_BusinessPhone = BusinessLicenseRegistrationStep2.sOPO3_BusinessPhone,
                sOPO3_HomePhone = BusinessLicenseRegistrationStep2.sOPO3_HomePhone,
                sOPO3_HomeAddress = BusinessLicenseRegistrationStep2.sOPO3_HomeAddress,
                sOPO3_City = BusinessLicenseRegistrationStep2.sOPO3_City,
                sOPO3_State = BusinessLicenseRegistrationStep2.sOPO3_State,
                sOPO3_Zip = BusinessLicenseRegistrationStep2.sOPO3_Zip
            };

            string buf2 = await obj.UpdateAsync2(id, buf);

            if (buf2 == null) return NotFound();

            return Ok(buf2);
        }

        [HttpPut]
        [Route("~/C_BusinessLicenses/BusinessLicenseRegistrationStep3")]
        [Authorize(Roles = "vendor")]
        public async Task<IActionResult> UpdateAsync3(int id, [FromBody] DTO_BusinessLicenseRegistrationStep3 BusinessLicenseRegistrationStep3)
        {
            if (!await ValidateUpdateAsync3(BusinessLicenseRegistrationStep3)) return BadRequest(ModelState);

            var buf = new D_BusinessLicense()
            {
                iType_LegalOrg = BusinessLicenseRegistrationStep3.iType_LegalOrg,
                bMember = BusinessLicenseRegistrationStep3.bMember,
                iOwned_SWST_Percent = BusinessLicenseRegistrationStep3.iOwned_SWST_Percent,
                iOwned_AmeriIndian_percent = BusinessLicenseRegistrationStep3.iOwned_AmeriIndian_percent,
                sGroupCode_1 = BusinessLicenseRegistrationStep3.sGroupCode_1,
                sSICCode_1 = BusinessLicenseRegistrationStep3.sSICCode_1,
                sGroupCode_2 = BusinessLicenseRegistrationStep3.sGroupCode_2,
                sSICCode_2 = BusinessLicenseRegistrationStep3.sSICCode_2,
                sGroupCode_3 = BusinessLicenseRegistrationStep3.sGroupCode_3,
                sSICCode_3 = BusinessLicenseRegistrationStep3.sSICCode_3,
                sGroupCode_4 = BusinessLicenseRegistrationStep3.sGroupCode_4,
                sSICCode_4 = BusinessLicenseRegistrationStep3.sSICCode_4,
                ibusiness_located = BusinessLicenseRegistrationStep3.ibusiness_located,
                directions_nearest_town = BusinessLicenseRegistrationStep3.directions_nearest_town
            };

            string buf2 = await obj.UpdateAsync3(id, buf);

            if (buf2 == null) return NotFound();

            return Ok(buf2);
        }

        [HttpPut]
        [Route("~/C_BusinessLicenses/BusinessLicenseRegistrationStep4")]
        [Authorize(Roles = "vendor")]
        public async Task<IActionResult> UpdateAsync4(int id, [FromBody] DTO_BusinessLicenseRegistrationStep4 BusinessLicenseRegistrationStep4)
        {
            if (!await ValidateUpdateAsync4(BusinessLicenseRegistrationStep4)) return BadRequest(ModelState);

            var buf = new D_BusinessLicense()
            {
                iReason_License = BusinessLicenseRegistrationStep4.iReason_License,
                prior_owner_Name = BusinessLicenseRegistrationStep4.prior_owner_Name,
                prior_owner_Title = BusinessLicenseRegistrationStep4.prior_owner_Title,
                prior_owner_BusinessPhone = BusinessLicenseRegistrationStep4.prior_owner_BusinessPhone,
                prior_owner_HomePhone = BusinessLicenseRegistrationStep4.prior_owner_HomePhone,
                prior_owner_HomeAddress = BusinessLicenseRegistrationStep4.prior_owner_HomeAddress,
                prior_owner_City = BusinessLicenseRegistrationStep4.prior_owner_City,
                prior_owner_State = BusinessLicenseRegistrationStep4.prior_owner_State,
                prior_owner_Zip = BusinessLicenseRegistrationStep4.prior_owner_Zip,
                sCTT_Id_Current = BusinessLicenseRegistrationStep4.sCTT_Id_Current,
                bCTT_Id_Cancel = BusinessLicenseRegistrationStep4.bCTT_Id_Cancel,
                dCTT_Id_CancelEff = BusinessLicenseRegistrationStep4.dCTT_Id_CancelEff
            };

            string buf2 = await obj.UpdateAsync4(id, buf);

            if (buf2 == null) return NotFound();

            return Ok(buf2);
        }

        [HttpPut]
        [Route("~/C_BusinessLicenses/BusinessLicenseRegistrationStep5")]
        [Authorize(Roles = "vendor")]
        public async Task<IActionResult> UpdateAsync5(int id, [FromBody] DTO_BusinessLicenseRegistrationStep5 BusinessLicenseRegistrationStep5)
        {
            var buf1 = await obj.GetMemberAsync(id);
            var buf3 = await obj.GetMembersAsync();
            var buf4 = await obj.GetAllCountAsync();

            var buf = new D_BusinessLicense()
            {
                vendor = BusinessLicenseRegistrationStep5.vendor,
                applicationDate = BusinessLicenseRegistrationStep5.applicationDate,
                sLicenseNo = buf1.bMember == true ? $"Mb-{buf3 + 1}" : $"Nm-{buf4 - buf3 + 1}",
                dStartDate = BusinessLicenseRegistrationStep5.dStartDate,
                dEndDate = BusinessLicenseRegistrationStep5.dEndDate,
                sPwd = BusinessLicenseRegistrationStep5.sPwd,
                secretQuestion = BusinessLicenseRegistrationStep5.secretQuestion,
                secretAnswer = BusinessLicenseRegistrationStep5.secretAnswer,
                sEmail = BusinessLicenseRegistrationStep5.sEmail
            };

            string buf2 = await obj.UpdateAsync5(id, buf);

            if (buf2 == null) return NotFound();

            return Ok(buf2);
        }

        #region Private methods
        private async Task<bool> ValidateAddAsync(DTO_BusinessLicenseRegistrationStep1 BusinessLicenseRegistrationStep1)
        {
            var buf = await APIDbContext.Cities.AnyAsync(x => x.City == BusinessLicenseRegistrationStep1.sBusiness_City && x.D_State.State_id == BusinessLicenseRegistrationStep1.sBusiness_State && x.ZIP == BusinessLicenseRegistrationStep1.sBusiness_Zip);

            if (!buf) ModelState.AddModelError(nameof(BusinessLicenseRegistrationStep1.sBusiness_City), $"{nameof(BusinessLicenseRegistrationStep1.sBusiness_City)} or {nameof(BusinessLicenseRegistrationStep1.sBusiness_State)} or {nameof(BusinessLicenseRegistrationStep1.sBusiness_Zip)} is invalid.");

            if (!String.IsNullOrEmpty(BusinessLicenseRegistrationStep1.sMailing_City) || !String.IsNullOrEmpty(BusinessLicenseRegistrationStep1.sMailing_State) || !String.IsNullOrEmpty(BusinessLicenseRegistrationStep1.sMailing_Zip))
            {
                buf = await APIDbContext.Cities.AnyAsync(x => x.City == BusinessLicenseRegistrationStep1.sMailing_City && x.D_State.State_id == BusinessLicenseRegistrationStep1.sMailing_State && x.ZIP == BusinessLicenseRegistrationStep1.sMailing_Zip);

                if (!buf) ModelState.AddModelError(nameof(BusinessLicenseRegistrationStep1.sMailing_City), $"{nameof(BusinessLicenseRegistrationStep1.sMailing_City)} or {nameof(BusinessLicenseRegistrationStep1.sMailing_State)} or {nameof(BusinessLicenseRegistrationStep1.sMailing_Zip)} is invalid.");
            }

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }

        private async Task<bool> ValidateUpdateAsync2(DTO_BusinessLicenseRegistrationStep2 BusinessLicenseRegistrationStep2)
        {
            if (!String.IsNullOrEmpty(BusinessLicenseRegistrationStep2.sOPO1_City) || !String.IsNullOrEmpty(BusinessLicenseRegistrationStep2.sOPO1_State) || !String.IsNullOrEmpty(BusinessLicenseRegistrationStep2.sOPO1_Zip))
            {
                var buf = await APIDbContext.Cities.AnyAsync(x => x.City == BusinessLicenseRegistrationStep2.sOPO1_City && x.D_State.State_id == BusinessLicenseRegistrationStep2.sOPO1_State && x.ZIP == BusinessLicenseRegistrationStep2.sOPO1_Zip);

                if (!buf) ModelState.AddModelError(nameof(BusinessLicenseRegistrationStep2.sOPO1_City), $"{nameof(BusinessLicenseRegistrationStep2.sOPO1_City)} or {nameof(BusinessLicenseRegistrationStep2.sOPO1_State)} or {nameof(BusinessLicenseRegistrationStep2.sOPO1_Zip)} is invalid.");
            }

            if (!String.IsNullOrEmpty(BusinessLicenseRegistrationStep2.sOPO2_City) || !String.IsNullOrEmpty(BusinessLicenseRegistrationStep2.sOPO2_State) || !String.IsNullOrEmpty(BusinessLicenseRegistrationStep2.sOPO2_Zip))
            {
                var buf = await APIDbContext.Cities.AnyAsync(x => x.City == BusinessLicenseRegistrationStep2.sOPO2_City && x.D_State.State_id == BusinessLicenseRegistrationStep2.sOPO2_State && x.ZIP == BusinessLicenseRegistrationStep2.sOPO2_Zip);

                if (!buf) ModelState.AddModelError(nameof(BusinessLicenseRegistrationStep2.sOPO2_City), $"{nameof(BusinessLicenseRegistrationStep2.sOPO2_City)} or {nameof(BusinessLicenseRegistrationStep2.sOPO2_State)} or {nameof(BusinessLicenseRegistrationStep2.sOPO2_Zip)} is invalid.");
            }

            if (!String.IsNullOrEmpty(BusinessLicenseRegistrationStep2.sOPO3_City) || !String.IsNullOrEmpty(BusinessLicenseRegistrationStep2.sOPO3_State) || !String.IsNullOrEmpty(BusinessLicenseRegistrationStep2.sOPO3_Zip))
            {
                var buf = await APIDbContext.Cities.AnyAsync(x => x.City == BusinessLicenseRegistrationStep2.sOPO3_City && x.D_State.State_id == BusinessLicenseRegistrationStep2.sOPO3_State && x.ZIP == BusinessLicenseRegistrationStep2.sOPO3_Zip);

                if (!buf) ModelState.AddModelError(nameof(BusinessLicenseRegistrationStep2.sOPO3_City), $"{nameof(BusinessLicenseRegistrationStep2.sOPO3_City)} or {nameof(BusinessLicenseRegistrationStep2.sOPO3_State)} or {nameof(BusinessLicenseRegistrationStep2.sOPO3_Zip)} is invalid.");
            }

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }

        private async Task<bool> ValidateUpdateAsync3(DTO_BusinessLicenseRegistrationStep3 BusinessLicenseRegistrationStep3)
        {
            if (!String.IsNullOrEmpty(BusinessLicenseRegistrationStep3.sGroupCode_1) || BusinessLicenseRegistrationStep3.sSICCode_1 != null)
            {
                var buf = await APIDbContext.SICs.AnyAsync(x => x.D_SICHeader.sGroupCode == BusinessLicenseRegistrationStep3.sGroupCode_1 && x.sSICCode == BusinessLicenseRegistrationStep3.sSICCode_1);
                if (!buf) ModelState.AddModelError(nameof(BusinessLicenseRegistrationStep3), $"{nameof(BusinessLicenseRegistrationStep3.sGroupCode_1)} or {nameof(BusinessLicenseRegistrationStep3.sSICCode_1)} is invalid.");
            }

            if (!String.IsNullOrEmpty(BusinessLicenseRegistrationStep3.sGroupCode_2) || BusinessLicenseRegistrationStep3.sSICCode_2 != null)
            {
                var buf = await APIDbContext.SICs.AnyAsync(x => x.D_SICHeader.sGroupCode == BusinessLicenseRegistrationStep3.sGroupCode_2 && x.sSICCode == BusinessLicenseRegistrationStep3.sSICCode_2);
                if (!buf) ModelState.AddModelError(nameof(BusinessLicenseRegistrationStep3), $"{nameof(BusinessLicenseRegistrationStep3.sGroupCode_2)} or {nameof(BusinessLicenseRegistrationStep3.sSICCode_2)} is invalid.");
            }

            if (!String.IsNullOrEmpty(BusinessLicenseRegistrationStep3.sGroupCode_3) || BusinessLicenseRegistrationStep3.sSICCode_3 != null)
            {
                var buf = await APIDbContext.SICs.AnyAsync(x => x.D_SICHeader.sGroupCode == BusinessLicenseRegistrationStep3.sGroupCode_3 && x.sSICCode == BusinessLicenseRegistrationStep3.sSICCode_3);
                if (!buf) ModelState.AddModelError(nameof(BusinessLicenseRegistrationStep3), $"{nameof(BusinessLicenseRegistrationStep3.sGroupCode_3)} or {nameof(BusinessLicenseRegistrationStep3.sSICCode_3)} is invalid.");
            }

            if (!String.IsNullOrEmpty(BusinessLicenseRegistrationStep3.sGroupCode_4) || BusinessLicenseRegistrationStep3.sSICCode_4 != null)
            {
                var buf = await APIDbContext.SICs.AnyAsync(x => x.D_SICHeader.sGroupCode == BusinessLicenseRegistrationStep3.sGroupCode_4 && x.sSICCode == BusinessLicenseRegistrationStep3.sSICCode_4);
                if (!buf) ModelState.AddModelError(nameof(BusinessLicenseRegistrationStep3), $"{nameof(BusinessLicenseRegistrationStep3.sGroupCode_4)} or {nameof(BusinessLicenseRegistrationStep3.sSICCode_4)} is invalid.");
            }

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }

        private async Task<bool> ValidateUpdateAsync4(DTO_BusinessLicenseRegistrationStep4 BusinessLicenseRegistrationStep4)
        {
            if (!String.IsNullOrEmpty(BusinessLicenseRegistrationStep4.prior_owner_City) || !String.IsNullOrEmpty(BusinessLicenseRegistrationStep4.prior_owner_State) || !String.IsNullOrEmpty(BusinessLicenseRegistrationStep4.prior_owner_Zip))
            {
                var buf = await APIDbContext.Cities.AnyAsync(x => x.City == BusinessLicenseRegistrationStep4.prior_owner_City && x.D_State.State_id == BusinessLicenseRegistrationStep4.prior_owner_State && x.ZIP == BusinessLicenseRegistrationStep4.prior_owner_Zip);

                if (!buf) ModelState.AddModelError(nameof(BusinessLicenseRegistrationStep4.prior_owner_City), $"{nameof(BusinessLicenseRegistrationStep4.prior_owner_City)} or {nameof(BusinessLicenseRegistrationStep4.prior_owner_State)} or {nameof(BusinessLicenseRegistrationStep4.prior_owner_Zip)} is invalid.");
            }

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }
        #endregion
    }
}