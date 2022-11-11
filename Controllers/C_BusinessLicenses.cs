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
        private readonly I_BusinessLicense I_BusinessLicense;
        private readonly IMapper mapper;

        public C_BusinessLicenses(APIDbContext APIDbContext, I_BusinessLicense I_BusinessLicense, IMapper mapper)
        {
            this.APIDbContext = APIDbContext;
            this.I_BusinessLicense = I_BusinessLicense;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetListOfAllLicenses()
        {
            return Ok(mapper.Map<List<DTO_BusinessLicense>>(await I_BusinessLicense.GetListOfAllLicenses()));
        }

        [HttpGet]
        [Route("~/C_BusinessLicenses/Filter_Dates")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetListOfAllLicenses_Filter_Dates(DateTime applicationDate, DateTime dCTT_Id_CancelEff)
        {
            return Ok(mapper.Map<List<DTO_BusinessLicense>>(await I_BusinessLicense.GetListOfAllLicenses_Filter_Dates(applicationDate, dCTT_Id_CancelEff)));
        }

        [HttpGet]
        [Route("~/C_BusinessLicenses/Filter_SICs")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetListOfAllLicenses_Filter_SICs(string sGroupCode, int sSICCode)
        {
            return Ok(mapper.Map<List<DTO_BusinessLicense>>(await I_BusinessLicense.GetListOfAllLicenses_Filter_SICs(sGroupCode, sSICCode)));
        }

        [HttpPost]
        [Route("~/C_BusinessLicense/RegistrationStep1")]
        [Authorize(Roles = "vendor")]
        public async Task<IActionResult> AddNewLicense(DTO_BusinessLicenseRegistrationStep1 args)
        {
            if (!await ValidateAddNewLicense(args)) return BadRequest(ModelState);

            var buf = new D_BusinessLicense()
            {
                vendorUser_Id = args.vendorUser_Id,
                sBusinessname_Legal = args.sBusinessname_Legal,
                sName_First_Soleproprietor = args.sName_First_Soleproprietor,
                sName_Mi_Soleproprietor = args.sName_Mi_Soleproprietor,
                sName_Last_Soleproprietor = args.sName_Last_Soleproprietor,
                sBusinessName_trade = args.sBusinessName_trade,
                sFIDSSN = args.sFIDSSN,
                sBusiness_Address = args.sBusiness_Address,
                sBusiness_City = args.sBusiness_City,
                sBusiness_State = args.sBusiness_State,
                sBusiness_Zip = args.sBusiness_Zip,
                sMailing_Address = args.sMailing_Address,
                sMailing_City = args.sMailing_City,
                sMailing_State = args.sMailing_State,
                sMailing_Zip = args.sMailing_Zip,
                sPhoneNo_DayTime = args.sPhoneNo_DayTime,
                sPhoneNo_Other = args.sPhoneNo_Other,
                sFaxNo = args.sFaxNo
            };

            return Ok(await I_BusinessLicense.AddNewLicense(buf));
        }

        [HttpPut]
        [Route("~/C_BusinessLicense/RegistrationStep2")]
        [Authorize(Roles = "vendor")]
        public async Task<IActionResult> UpdateLicenseByIdStep2([FromBody] DTO_BusinessLicenseRegistrationStep2 args)
        {
            if (!await ValidateUpdateLicenseByIdStep2(args)) return BadRequest(ModelState);

            var buf = new D_BusinessLicense()
            {
                sOPO1_Name = args.sOPO1_Name,
                sOPO1_Title = args.sOPO1_Title,
                sOPO1_BusinessPhone = args.sOPO1_BusinessPhone,
                sOPO1_HomePhone = args.sOPO1_HomePhone,
                sOPO1_HomeAddress = args.sOPO1_HomeAddress,
                sOPO1_City = args.sOPO1_City,
                sOPO1_State = args.sOPO1_State,
                sOPO1_Zip = args.sOPO1_Zip,

                sOPO2_Name = args.sOPO2_Name,
                sOPO2_Title = args.sOPO2_Title,
                sOPO2_BusinessPhone = args.sOPO2_BusinessPhone,
                sOPO2_HomePhone = args.sOPO2_HomePhone,
                sOPO2_HomeAddress = args.sOPO2_HomeAddress,
                sOPO2_City = args.sOPO2_City,
                sOPO2_State = args.sOPO2_State,
                sOPO2_Zip = args.sOPO2_Zip,

                sOPO3_Name = args.sOPO3_Name,
                sOPO3_Title = args.sOPO3_Title,
                sOPO3_BusinessPhone = args.sOPO3_BusinessPhone,
                sOPO3_HomePhone = args.sOPO3_HomePhone,
                sOPO3_HomeAddress = args.sOPO3_HomeAddress,
                sOPO3_City = args.sOPO3_City,
                sOPO3_State = args.sOPO3_State,
                sOPO3_Zip = args.sOPO3_Zip
            };

            string answer = await I_BusinessLicense.UpdateLicenseByIdStep2(args.License_id, buf);

            if (answer == null) return NotFound();

            return Ok(answer);
        }

        [HttpPut]
        [Route("~/C_BusinessLicense/RegistrationStep3")]
        [Authorize(Roles = "vendor")]
        public async Task<IActionResult> UpdateLicenseByIdStep3([FromBody] DTO_BusinessLicenseRegistrationStep3 args)
        {
            if (!await ValidateUpdateLicenseByIdStep3(args)) return BadRequest(ModelState);

            var buf = new D_BusinessLicense()
            {
                iType_LegalOrg = args.iType_LegalOrg,
                bMember = args.bMember,
                iOwned_SWST_Percent = args.iOwned_SWST_Percent,
                iOwned_AmeriIndian_percent = args.iOwned_AmeriIndian_percent,
                sGroupCode_1 = args.sGroupCode_1,
                sSICCode_1 = args.sSICCode_1,
                sGroupCode_2 = args.sGroupCode_2,
                sSICCode_2 = args.sSICCode_2,
                sGroupCode_3 = args.sGroupCode_3,
                sSICCode_3 = args.sSICCode_3,
                sGroupCode_4 = args.sGroupCode_4,
                sSICCode_4 = args.sSICCode_4,
                ibusiness_located = args.ibusiness_located,
                directions_nearest_town = args.directions_nearest_town
            };

            string answer = await I_BusinessLicense.UpdateLicenseByIdStep3(args.License_id, buf);

            if (answer == null) return NotFound();

            return Ok(answer);
        }

        [HttpPut]
        [Route("~/C_BusinessLicense/RegistrationStep4")]
        [Authorize(Roles = "vendor")]
        public async Task<IActionResult> UpdateLicenseByIdStep4([FromBody] DTO_BusinessLicenseRegistrationStep4 args)
        {
            if (!await ValidateUpdateLicenseByIdStep4(args)) return BadRequest(ModelState);

            var buf = new D_BusinessLicense()
            {
                iReason_License = args.iReason_License,
                prior_owner_Name = args.prior_owner_Name,
                prior_owner_Title = args.prior_owner_Title,
                prior_owner_BusinessPhone = args.prior_owner_BusinessPhone,
                prior_owner_HomePhone = args.prior_owner_HomePhone,
                prior_owner_HomeAddress = args.prior_owner_HomeAddress,
                prior_owner_City = args.prior_owner_City,
                prior_owner_State = args.prior_owner_State,
                prior_owner_Zip = args.prior_owner_Zip,
                sCTT_Id_Current = args.sCTT_Id_Current,
                bCTT_Id_Cancel = args.bCTT_Id_Cancel,
                dCTT_Id_CancelEff = args.dCTT_Id_CancelEff
            };

            string answer = await I_BusinessLicense.UpdateLicenseByIdStep4(args.License_id, buf);

            if (answer == null) return NotFound();

            return Ok(answer);
        }

        [HttpPut]
        [Route("~/C_BusinessLicense/RegistrationStep5")]
        [Authorize(Roles = "vendor")]
        public async Task<IActionResult> UpdateLicenseByIdStep5([FromBody] DTO_BusinessLicenseRegistrationStep5 args)
        {
            if (!await ValidateUpdateLicenseByIdStep5(args)) return BadRequest(ModelState);

            var CountOfAllLicensesWithOnlyMembers = await I_BusinessLicense.GetCountOfAllLicensesWithOnlyMembers();
            var CountOfAllLicenses = await I_BusinessLicense.GetCountOfAllLicenses();

            var buf = new D_BusinessLicense()
            {
                applicationDate = DateTime.Now,
                sLicenseNo = args.bMember == true ? $"Mb-{CountOfAllLicensesWithOnlyMembers}" : $"Nm-{CountOfAllLicenses - CountOfAllLicensesWithOnlyMembers}",
                sPwd = args.sPwd,
                secretQuestion = args.secretQuestion,
                secretAnswer = args.secretAnswer,
                sEmail = args.sEmail
            };

            string answer = await I_BusinessLicense.UpdateLicenseByIdStep5(args.License_id, buf);

            if (answer == null) return NotFound();

            return Ok(answer);
        }

        #region Private methods
        private async Task<bool> ValidateAddNewLicense(DTO_BusinessLicenseRegistrationStep1 args)
        {
            if (!String.IsNullOrEmpty(args.sBusiness_City) && !String.IsNullOrEmpty(args.sBusiness_State) && !String.IsNullOrEmpty(args.sBusiness_Zip))
            {
                var buf = await APIDbContext.Cities.AnyAsync(x => x.City == args.sBusiness_City && x.D_State.State_id == args.sBusiness_State && x.ZIP == args.sBusiness_Zip);

                if (!buf) ModelState.AddModelError(nameof(args.sBusiness_City), $"{nameof(args.sBusiness_City)} or {nameof(args.sBusiness_State)} or {nameof(args.sBusiness_Zip)} is invalid.");
            }
            else ModelState.AddModelError(nameof(args.sBusiness_City), $"{nameof(args.sBusiness_City)} or {nameof(args.sBusiness_State)} or {nameof(args.sBusiness_Zip)} is invalid.");

            if (!String.IsNullOrEmpty(args.sMailing_City) && !String.IsNullOrEmpty(args.sMailing_State) && !String.IsNullOrEmpty(args.sMailing_Zip))
            {
                var buf = await APIDbContext.Cities.AnyAsync(x => x.City == args.sMailing_City && x.D_State.State_id == args.sMailing_State && x.ZIP == args.sMailing_Zip);

                if (!buf) ModelState.AddModelError(nameof(args.sMailing_City), $"{nameof(args.sMailing_City)} or {nameof(args.sMailing_State)} or {nameof(args.sMailing_Zip)} is invalid.");
            }
            else if (!String.IsNullOrEmpty(args.sMailing_City) || !String.IsNullOrEmpty(args.sMailing_State) || !String.IsNullOrEmpty(args.sMailing_Zip)) ModelState.AddModelError(nameof(args.sMailing_City), $"{nameof(args.sMailing_City)} or {nameof(args.sMailing_State)} or {nameof(args.sMailing_Zip)} is invalid.");

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }

        private async Task<bool> ValidateUpdateLicenseByIdStep2(DTO_BusinessLicenseRegistrationStep2 args)
        {
            if (!String.IsNullOrEmpty(args.sOPO1_City) && !String.IsNullOrEmpty(args.sOPO1_State) && !String.IsNullOrEmpty(args.sOPO1_Zip))
            {
                var buf = await APIDbContext.Cities.AnyAsync(x => x.City == args.sOPO1_City && x.D_State.State_id == args.sOPO1_State && x.ZIP == args.sOPO1_Zip);

                if (!buf) ModelState.AddModelError(nameof(args.sOPO1_City), $"{nameof(args.sOPO1_City)} or {nameof(args.sOPO1_State)} or {nameof(args.sOPO1_Zip)} is invalid.");
            }
            else if (!String.IsNullOrEmpty(args.sOPO1_City) || !String.IsNullOrEmpty(args.sOPO1_State) || !String.IsNullOrEmpty(args.sOPO1_Zip)) ModelState.AddModelError(nameof(args.sOPO1_City), $"{nameof(args.sOPO1_City)} or {nameof(args.sOPO1_State)} or {nameof(args.sOPO1_Zip)} is invalid.");

            if (!String.IsNullOrEmpty(args.sOPO2_City) && !String.IsNullOrEmpty(args.sOPO2_State) && !String.IsNullOrEmpty(args.sOPO2_Zip))
            {
                var buf = await APIDbContext.Cities.AnyAsync(x => x.City == args.sOPO2_City && x.D_State.State_id == args.sOPO2_State && x.ZIP == args.sOPO2_Zip);

                if (!buf) ModelState.AddModelError(nameof(args.sOPO2_City), $"{nameof(args.sOPO2_City)} or {nameof(args.sOPO2_State)} or {nameof(args.sOPO2_Zip)} is invalid.");
            }
            else if (!String.IsNullOrEmpty(args.sOPO2_City) || !String.IsNullOrEmpty(args.sOPO2_State) || !String.IsNullOrEmpty(args.sOPO2_Zip)) ModelState.AddModelError(nameof(args.sOPO2_City), $"{nameof(args.sOPO2_City)} or {nameof(args.sOPO2_State)} or {nameof(args.sOPO2_Zip)} is invalid.");

            if (!String.IsNullOrEmpty(args.sOPO3_City) && !String.IsNullOrEmpty(args.sOPO3_State) && !String.IsNullOrEmpty(args.sOPO3_Zip))
            {
                var buf = await APIDbContext.Cities.AnyAsync(x => x.City == args.sOPO3_City && x.D_State.State_id == args.sOPO3_State && x.ZIP == args.sOPO3_Zip);

                if (!buf) ModelState.AddModelError(nameof(args.sOPO3_City), $"{nameof(args.sOPO3_City)} or {nameof(args.sOPO3_State)} or {nameof(args.sOPO3_Zip)} is invalid.");
            }
            else if (!String.IsNullOrEmpty(args.sOPO3_City) || !String.IsNullOrEmpty(args.sOPO3_State) || !String.IsNullOrEmpty(args.sOPO3_Zip)) ModelState.AddModelError(nameof(args.sOPO3_City), $"{nameof(args.sOPO3_City)} or {nameof(args.sOPO3_State)} or {nameof(args.sOPO3_Zip)} is invalid.");

            var Lisense_Id = await I_BusinessLicense.GetMaxIdOftLicense_Filter_Vendor(args.vendorUser_Id);

            if (Lisense_Id != args.License_id) ModelState.AddModelError(nameof(args.License_id), $"{nameof(args.License_id)} is invalid.");

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }

        private async Task<bool> ValidateUpdateLicenseByIdStep3(DTO_BusinessLicenseRegistrationStep3 args)
        {
            if (!String.IsNullOrEmpty(args.sGroupCode_1) && args.sSICCode_1 != null)
            {
                var buf = await APIDbContext.SICs.AnyAsync(x => x.D_SICHeader.sGroupCode == args.sGroupCode_1 && x.sSICCode == args.sSICCode_1);
                if (!buf) ModelState.AddModelError(nameof(args), $"{nameof(args.sGroupCode_1)} or {nameof(args.sSICCode_1)} is invalid.");
            }
            else if (!String.IsNullOrEmpty(args.sGroupCode_1) || args.sSICCode_1 != null) ModelState.AddModelError(nameof(args), $"{nameof(args.sGroupCode_1)} or {nameof(args.sSICCode_1)} is invalid.");

            if (!String.IsNullOrEmpty(args.sGroupCode_2) && args.sSICCode_2 != null)
            {
                var buf = await APIDbContext.SICs.AnyAsync(x => x.D_SICHeader.sGroupCode == args.sGroupCode_2 && x.sSICCode == args.sSICCode_2);
                if (!buf) ModelState.AddModelError(nameof(args), $"{nameof(args.sGroupCode_2)} or {nameof(args.sSICCode_2)} is invalid.");
            }
            else if (!String.IsNullOrEmpty(args.sGroupCode_2) || args.sSICCode_2 != null) ModelState.AddModelError(nameof(args), $"{nameof(args.sGroupCode_2)} or {nameof(args.sSICCode_2)} is invalid.");

            if (!String.IsNullOrEmpty(args.sGroupCode_3) && args.sSICCode_3 != null)
            {
                var buf = await APIDbContext.SICs.AnyAsync(x => x.D_SICHeader.sGroupCode == args.sGroupCode_3 && x.sSICCode == args.sSICCode_3);
                if (!buf) ModelState.AddModelError(nameof(args), $"{nameof(args.sGroupCode_3)} or {nameof(args.sSICCode_3)} is invalid.");
            }
            else if (!String.IsNullOrEmpty(args.sGroupCode_3) || args.sSICCode_3 != null) ModelState.AddModelError(nameof(args), $"{nameof(args.sGroupCode_3)} or {nameof(args.sSICCode_3)} is invalid.");


            if (!String.IsNullOrEmpty(args.sGroupCode_4) && args.sSICCode_4 != null)
            {
                var buf = await APIDbContext.SICs.AnyAsync(x => x.D_SICHeader.sGroupCode == args.sGroupCode_4 && x.sSICCode == args.sSICCode_4);
                if (!buf) ModelState.AddModelError(nameof(args), $"{nameof(args.sGroupCode_4)} or {nameof(args.sSICCode_4)} is invalid.");
            }
            else if (!String.IsNullOrEmpty(args.sGroupCode_4) || args.sSICCode_4 != null) ModelState.AddModelError(nameof(args), $"{nameof(args.sGroupCode_4)} or {nameof(args.sSICCode_4)} is invalid.");

            var Lisense_Id = await I_BusinessLicense.GetMaxIdOftLicense_Filter_Vendor(args.vendorUser_Id);

            if (Lisense_Id != args.License_id) ModelState.AddModelError(nameof(args.License_id), $"{nameof(args.License_id)} is invalid.");

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }

        private async Task<bool> ValidateUpdateLicenseByIdStep4(DTO_BusinessLicenseRegistrationStep4 args)
        {
            if (!String.IsNullOrEmpty(args.prior_owner_City) && !String.IsNullOrEmpty(args.prior_owner_State) && !String.IsNullOrEmpty(args.prior_owner_Zip))
            {
                var buf = await APIDbContext.Cities.AnyAsync(x => x.City == args.prior_owner_City && x.D_State.State_id == args.prior_owner_State && x.ZIP == args.prior_owner_Zip);

                if (!buf) ModelState.AddModelError(nameof(args.prior_owner_City), $"{nameof(args.prior_owner_City)} or {nameof(args.prior_owner_State)} or {nameof(args.prior_owner_Zip)} is invalid.");
            }
            else if (!String.IsNullOrEmpty(args.prior_owner_City) || !String.IsNullOrEmpty(args.prior_owner_State) || !String.IsNullOrEmpty(args.prior_owner_Zip)) ModelState.AddModelError(nameof(args.prior_owner_City), $"{nameof(args.prior_owner_City)} or {nameof(args.prior_owner_State)} or {nameof(args.prior_owner_Zip)} is invalid.");

            var Lisense_Id = await I_BusinessLicense.GetMaxIdOftLicense_Filter_Vendor(args.vendorUser_Id);

            if (Lisense_Id != args.License_id) ModelState.AddModelError(nameof(args.License_id), $"{nameof(args.License_id)} is invalid.");

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }

        private async Task<bool> ValidateUpdateLicenseByIdStep5(DTO_BusinessLicenseRegistrationStep5 args)
        {
            var Lisense_Id = await I_BusinessLicense.GetMaxIdOftLicense_Filter_Vendor(args.vendorUser_Id);

            if (Lisense_Id != args.License_id) ModelState.AddModelError(nameof(args.License_id), $"{nameof(args.License_id)} is invalid.");

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }
        #endregion
    }
}