using API.Data;
using API.Models.Domain;
using API.Models.DTO;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_BusinessLicenses : Controller
    {
        private readonly APIDbContext APIDbContext;
        private readonly I_User I_User;
        private readonly I_BusinessLicense I_BusinessLicense;

        public C_BusinessLicenses(APIDbContext APIDbContext, I_User I_User, I_BusinessLicense I_BusinessLicense)
        {
            this.APIDbContext = APIDbContext;
            this.I_User = I_User;
            this.I_BusinessLicense = I_BusinessLicense;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllBusinessLicenses()
        {
            return Ok(await I_BusinessLicense.GetAllBusinessLicenses());
        }

        [HttpGet]
        [Route("~/C_BusinessLicensesFilterDates")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetBusinessLicensesFilterDates(DateTime startEffectiveDate, DateTime cancelEffectiveDate)
        {
            if (!ValidateGetBusinessLicensesFilterDates(startEffectiveDate, cancelEffectiveDate)) return BadRequest(ModelState);

            return Ok(await I_BusinessLicense.GetBusinessLicensesFilterDates(startEffectiveDate, cancelEffectiveDate));
        }

        [HttpGet]
        [Route("~/C_BusinessLicensesFilterSICCode")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetBusinessLicensesFilterSICCode(int? groupOfSICCodesId, int? SICCodeId)
        {
            if (!await ValidateGetBusinessLicensesFilterSICCode(groupOfSICCodesId, SICCodeId)) return BadRequest(ModelState);
            if (groupOfSICCodesId != null && SICCodeId != null) return Ok(await I_BusinessLicense.GetBusinessLicensesFilterSICCode((int)groupOfSICCodesId, (int)SICCodeId));

            return Ok();
        }

        [HttpPost]
        [Route("~/C_BusinessLicense/RegistrationStep1")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddNewBusinessLicense(DTO_BusinessLicenseRegStep1 args)
        {
            if (!await ValidateAddNewBusinessLicense(args)) return BadRequest(ModelState);

            var user = await I_User.GetUser(User.FindFirst(ClaimTypes.Email)?.Value);

            var buf = new D_BusinessLicense()
            {
                userId = user.id,
                businessName = args.businessName,
                firstName = args.firstName,
                middleInitial = args.middleInitial,
                lastName = args.lastName,
                businessTradeName = args.businessTradeName,
                ID_SSN = args.ID_SSN,
                businessAddress = args.businessAddress,
                businessCityId = args.businessCityId,
                businessStateId = args.businessStateId,
                businessZipCodeId = args.businessZipCodeId,
                mailingAddress = args.mailingAddress,
                mailingCityId = args.mailingCityId,
                mailingStateId = args.mailingStateId,
                mailingZipCodeId = args.mailingZipCodeId,
                dayTimePhone = args.dayTimePhone,
                otherPhone = args.otherPhone,
                fax = args.fax,
                startEffectiveDate = DateTime.Now
            };

            await I_BusinessLicense.AddNewBusinessLicense(buf);

            return Ok();
        }

        [HttpPut]
        [Route("~/C_BusinessLicense/RegistrationStep2")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateBusinessLicenseStep2([FromBody] DTO_BusinessLicenseRegStep2 args)
        {
            if (!await ValidateUpdateBusinessLicenseStep2(args)) return BadRequest(ModelState);

            var user = await I_User.GetUser(User.FindFirst(ClaimTypes.Email)?.Value);

            var licenseId = await I_BusinessLicense.GetLastBusinessLicenseIdForUser(user.id);

            var buf = new D_BusinessLicense()
            {
                listAllOwnersPartnersOfficers = args.listAllOwnersPartnersOfficers,

                name1 = args.name1,
                title1 = args.title1,
                businessPhone1 = args.businessPhone1,
                homePhone1 = args.homePhone1,
                homeAddress1 = args.homeAddress1,
                city1Id = args.city1Id,
                state1Id = args.state1Id,
                zipCode1Id = args.zipCode1Id,

                name2 = args.name2,
                title2 = args.title2,
                businessPhone2 = args.businessPhone2,
                homePhone2 = args.homePhone2,
                homeAddress2 = args.homeAddress2,
                city2Id = args.city2Id,
                state2Id = args.state2Id,
                zipCode2Id = args.zipCode2Id,

                name3 = args.name3,
                title3 = args.title3,
                businessPhone3 = args.businessPhone3,
                homePhone3 = args.homePhone3,
                homeAddress3 = args.homeAddress3,
                city3Id = args.city3Id,
                state3Id = args.state3Id,
                zipCode3Id = args.zipCode3Id,

                name4 = args.name4,
                title4 = args.title4,
                businessPhone4 = args.businessPhone4,
                homePhone4 = args.homePhone4,
                homeAddress4 = args.homeAddress4,
                city4Id = args.city4Id,
                state4Id = args.state4Id,
                zipCode4Id = args.zipCode4Id
            };

            await I_BusinessLicense.UpdateBusinessLicenseStep2(licenseId, buf);

            return Ok();
        }

        [HttpPut]
        [Route("~/C_BusinessLicense/RegistrationStep3")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateBusinessLicenseStep3([FromBody] DTO_BusinessLicenseRegStep3 args)
        {
            if (!await ValidateUpdateBusinessLicenseStep3(args)) return BadRequest(ModelState);

            var user = await I_User.GetUser(User.FindFirst(ClaimTypes.Email)?.Value);

            var licenseId = await I_BusinessLicense.GetLastBusinessLicenseIdForUser(user.id);

            var buf = new D_BusinessLicense()
            {
                typeOfLegalOrganization = args.typeOfLegalOrganization,
                member = args.member,
                percentageIsOwnedBySissetonWahpetonOyateMember = args.percentageIsOwnedBySissetonWahpetonOyateMember,
                percentageIsOwnedByAmericanIndians = args.percentageIsOwnedByAmericanIndians,
                groupOfSICCodes1Id = args.groupOfSICCodes1Id,
                SICCode1Id = args.SICCode1Id,
                groupOfSICCodes2Id = args.groupOfSICCodes2Id,
                SICCode2Id = args.SICCode2Id,
                groupOfSICCodes3Id = args.groupOfSICCodes3Id,
                SICCode3Id = args.SICCode3Id,
                groupOfSICCodes4Id = args.groupOfSICCodes4Id,
                SICCode4Id = args.SICCode4Id
            };

            await I_BusinessLicense.UpdateBusinessLicenseStep3(licenseId, buf);

            return Ok();
        }

        [HttpPut]
        [Route("~/C_BusinessLicense/RegistrationStep4")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateBusinessLicenseStep4([FromBody] DTO_BusinessLicenseRegStep4 args)
        {
            if (!await ValidateUpdateBusinessLicenseStep4(args)) return BadRequest(ModelState);

            var user = await I_User.GetUser(User.FindFirst(ClaimTypes.Email)?.Value);

            var licenseId = await I_BusinessLicense.GetLastBusinessLicenseIdForUser(user.id);

            var buf = new D_BusinessLicense()
            {
                licenseReason = args.licenseReason,
                priorOwnerAddress = args.priorOwnerAddress,
                priorOwnerCityId = args.priorOwnerCityId,
                priorOwnerStateId = args.priorOwnerStateId,
                priorOwnerZipCodeId = args.priorOwnerZipCodeId,
                currentTribalTaxIDnumber = args.currentTribalTaxIDnumber,
                shouldAnyNumberBeCancelled = args.shouldAnyNumberBeCancelled,
                cancelEffectiveDate = args.cancelEffectiveDate
            };

            await I_BusinessLicense.UpdateBusinessLicenseStep4(licenseId, buf);

            return Ok();
        }

        [HttpPut]
        [Route("~/C_BusinessLicense/RegistrationStep5")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateBusinessLicenseStep5([FromBody] DTO_BusinessLicenseRegStep5 args)
        {
            var CountOfAllBusinessLicensesWithOnlyMembers = await I_BusinessLicense.GetCountOfAllBusinessLicensesWithOnlyMembers();
            var CountOfAllBusinessLicenses = await I_BusinessLicense.GetCountOfAllBusinessLicenses();

            var user = await I_User.GetUser(User.FindFirst(ClaimTypes.Email)?.Value);

            var licenseId = await I_BusinessLicense.GetLastBusinessLicenseIdForUser(user.id);

            var license = await I_BusinessLicense.GetBusinessLicense(licenseId);

            var buf = new D_BusinessLicense()
            {
                name = license.member == true ? $"Mb-{CountOfAllBusinessLicensesWithOnlyMembers}" : $"Nm-{CountOfAllBusinessLicenses - CountOfAllBusinessLicensesWithOnlyMembers}",
                password = args.password,
                secretQuestion = args.secretQuestion,
                secretAnswer = args.secretAnswer,
                email = args.email
            };

            await I_BusinessLicense.UpdateBusinessLicenseStep5(licenseId, buf);

            return Ok();
        }

        #region Private methods
        private async Task<string> Check_City_State_ZipCode(int cityId, int stateId, int zipCodeId)
        {
            var buf1 = await APIDbContext.Cities.FirstOrDefaultAsync(x => x.id == cityId && x.state.id == stateId);

            if (buf1 == null) return "City or State is invalid.";

            var buf2 = await APIDbContext.ZipCodes.AnyAsync(x => x.city.id == buf1.id && x.id == zipCodeId);

            if (!buf2) return "Zip code is invalid.";

            return "";
        }

        private async Task<string> Check_GroupOfSICCodes_SICCodeId(int groupOfSICCodesId, int SICCodeId)
        {
            var buf = await APIDbContext.SICCodes.AnyAsync(x => x.groupOfSICCodes.id == groupOfSICCodesId && x.id == SICCodeId);

            if (!buf) return "Group Of SIC Code or SIC Code is invalid.";

            return "";
        }

        private bool ValidateGetBusinessLicensesFilterDates(DateTime? startEffectiveDate, DateTime? cancelEffectiveDate)
        {
            if (startEffectiveDate == null && cancelEffectiveDate != null || startEffectiveDate != null && cancelEffectiveDate == null || startEffectiveDate != null && cancelEffectiveDate != null && startEffectiveDate >= cancelEffectiveDate)

                ModelState.AddModelError("Dates", $"{nameof(startEffectiveDate)} or {nameof(cancelEffectiveDate)} is invalid.");

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }

        private async Task<bool> ValidateGetBusinessLicensesFilterSICCode(int? groupOfSICCodesId, int? SICCodeId)
        {
            if (groupOfSICCodesId == null || SICCodeId == null) ModelState.AddModelError("Data", $"{nameof(groupOfSICCodesId)} or {nameof(SICCodeId)} is invalid.");
            else if (ModelState.ErrorCount == 0)
            {
                var buf = await Check_GroupOfSICCodes_SICCodeId((int)groupOfSICCodesId, (int)SICCodeId);
                if (buf != "") ModelState.AddModelError("Data", buf);
            }

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }

        private async Task<bool> ValidateAddNewBusinessLicense(DTO_BusinessLicenseRegStep1 args)
        {
            var buf1 = await Check_City_State_ZipCode(args.businessCityId, args.businessStateId, args.businessZipCodeId);
            if (buf1 != "") ModelState.AddModelError(nameof(args), buf1);

            if (ModelState.ErrorCount == 0)
            {
                if (args.mailingAddress != null && args.mailingCityId != null && args.mailingStateId != null && args.mailingZipCodeId != null)
                {
                    var buf2 = await Check_City_State_ZipCode((int)args.mailingCityId, (int)args.mailingStateId, (int)args.mailingZipCodeId);
                    if (buf2 != "") ModelState.AddModelError(nameof(args), buf2);
                }
                else if (args.mailingCityId != null || args.mailingStateId != null || args.mailingZipCodeId != null) ModelState.AddModelError(nameof(args), "City or State or Zip code is invalid.");
            }

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }

        private async Task<bool> ValidateUpdateBusinessLicenseStep2(DTO_BusinessLicenseRegStep2 args)
        {
            if (args.homeAddress1 != null && args.city1Id != null && args.state1Id != null && args.zipCode1Id != null)
            {
                var buf1 = await Check_City_State_ZipCode((int)args.city1Id, (int)args.state1Id, (int)args.zipCode1Id);
                if (buf1 != "") ModelState.AddModelError(nameof(args), buf1);
            }
            else if (args.city1Id != null || args.state1Id != null || args.zipCode1Id != null) ModelState.AddModelError(nameof(args), "City or State or Zip code is invalid.");

            if (ModelState.ErrorCount == 0)
            {
                if (args.homeAddress2 != null && args.city2Id != null && args.state2Id != null && args.zipCode2Id != null)
                {
                    var buf2 = await Check_City_State_ZipCode((int)args.city2Id, (int)args.state2Id, (int)args.zipCode2Id);
                    if (buf2 != "") ModelState.AddModelError(nameof(args), buf2);
                }
                else if (args.city2Id != null || args.state2Id != null || args.zipCode2Id != null) ModelState.AddModelError(nameof(args), "City or State or Zip code is invalid.");
            }

            if (ModelState.ErrorCount == 0)
            {
                if (args.homeAddress3 != null && args.city3Id != null && args.state3Id != null && args.zipCode3Id != null)
                {
                    var buf3 = await Check_City_State_ZipCode((int)args.city3Id, (int)args.state3Id, (int)args.zipCode3Id);
                    if (buf3 != "") ModelState.AddModelError(nameof(args), buf3);
                }
                else if (args.city3Id != null || args.state3Id != null || args.zipCode3Id != null) ModelState.AddModelError(nameof(args), "City or State or Zip code is invalid.");
            }

            if (ModelState.ErrorCount == 0)
            {
                if (args.homeAddress4 != null && args.city4Id != null && args.state4Id != null && args.zipCode4Id != null)
                {
                    var buf4 = await Check_City_State_ZipCode((int)args.city4Id, (int)args.state4Id, (int)args.zipCode4Id);
                    if (buf4 != "") ModelState.AddModelError(nameof(args), buf4);
                }
                else if (args.city4Id != null || args.state4Id != null || args.zipCode4Id != null) ModelState.AddModelError(nameof(args), "City or State or Zip code is invalid.");
            }

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }

        private async Task<bool> ValidateUpdateBusinessLicenseStep3(DTO_BusinessLicenseRegStep3 args)
        {
            if (args.groupOfSICCodes1Id != null && args.SICCode1Id != null)
            {
                var buf1 = await Check_GroupOfSICCodes_SICCodeId((int)args.groupOfSICCodes1Id, (int)args.SICCode1Id);
                if (buf1 != "") ModelState.AddModelError(nameof(args), buf1);
            }
            else if (args.groupOfSICCodes1Id != null || args.SICCode1Id != null) ModelState.AddModelError(nameof(args), "Group Of SIC Code or SIC Code is invalid.");

            if (ModelState.ErrorCount == 0)
            {
                if (args.groupOfSICCodes2Id != null && args.SICCode2Id != null)
                {
                    var buf2 = await Check_GroupOfSICCodes_SICCodeId((int)args.groupOfSICCodes2Id, (int)args.SICCode2Id);
                    if (buf2 != "") ModelState.AddModelError(nameof(args), buf2);
                }
                else if (args.groupOfSICCodes2Id != null || args.SICCode2Id != null) ModelState.AddModelError(nameof(args), "Group Of SIC Code or SIC Code is invalid.");
            }

            if (ModelState.ErrorCount == 0)
            {
                if (args.groupOfSICCodes3Id != null && args.SICCode3Id != null)
                {
                    var buf3 = await Check_GroupOfSICCodes_SICCodeId((int)args.groupOfSICCodes3Id, (int)args.SICCode3Id);
                    if (buf3 != "") ModelState.AddModelError(nameof(args), buf3);
                }
                else if (args.groupOfSICCodes3Id != null || args.SICCode3Id != null) ModelState.AddModelError(nameof(args), "Group Of SIC Code or SIC Code is invalid.");
            }

            if (ModelState.ErrorCount == 0)
            {
                if (args.groupOfSICCodes4Id != null && args.SICCode4Id != null)
                {
                    var buf4 = await Check_GroupOfSICCodes_SICCodeId((int)args.groupOfSICCodes4Id, (int)args.SICCode4Id);
                    if (buf4 != "") ModelState.AddModelError(nameof(args), buf4);
                }
                else if (args.groupOfSICCodes4Id != null || args.SICCode4Id != null) ModelState.AddModelError(nameof(args), "Group Of SIC Code or SIC Code is invalid.");
            }

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }

        private async Task<bool> ValidateUpdateBusinessLicenseStep4(DTO_BusinessLicenseRegStep4 args)
        {
            if (args.priorOwnerAddress != null && args.priorOwnerCityId != null && args.priorOwnerStateId != null && args.priorOwnerZipCodeId != null)
            {
                var buf = await Check_City_State_ZipCode((int)args.priorOwnerCityId, (int)args.priorOwnerStateId, (int)args.priorOwnerZipCodeId);
                if (buf != "") ModelState.AddModelError(nameof(args), buf);
            }
            else if (args.priorOwnerCityId != null || args.priorOwnerStateId != null || args.priorOwnerZipCodeId != null) ModelState.AddModelError(nameof(args), "City or State or Zip code is invalid.");

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }
        #endregion
    }
}