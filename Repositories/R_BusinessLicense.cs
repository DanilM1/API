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

        public async Task<bool> AddNewBusinessLicense(D_BusinessLicense license)
        {
            await APIDbContext.BusinessLicenses.AddAsync(license);
            await APIDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DTO_BusinessLicense>> GetAllBusinessLicenses()
        {
            var query = from License in APIDbContext.BusinessLicenses
                        from User in APIDbContext.Users
                        from ZipCode in APIDbContext.ZipCodes
                        where
                            License.userId == User.id &&
                            License.businessCityId == ZipCode.city.id &&
                            License.businessStateId == ZipCode.city.state.id &&
                            License.businessZipCodeId == ZipCode.id
                        select new
                        {
                            username = User.name,
                            license = License.name,
                            startEffectiveDate = License.startEffectiveDate,
                            cancelEffectiveDate = License.cancelEffectiveDate,
                            firstName = License.firstName,
                            lastName = License.lastName,
                            businessAddress = License.businessAddress,
                            businessCity = ZipCode.city.name,
                            businessState = ZipCode.city.state.name,
                            businessZipCode = ZipCode.name,
                            dayTimePhone = License.dayTimePhone,
                            mailingAddress = License.mailingAddress
                        };

            var list = await query.ToListAsync().ConfigureAwait(false);

            return list.Select(x => new DTO_BusinessLicense()
            {
                username = x.username,
                license = x.license,
                startEffectiveDate = x.startEffectiveDate,
                cancelEffectiveDate = x.cancelEffectiveDate,
                firstName = x.firstName,
                lastName = x.lastName,
                businessAddress = x.businessAddress,
                businessCity = x.businessCity,
                businessState = x.businessState,
                businessZipCode = x.businessZipCode,
                dayTimePhone = x.dayTimePhone,
                mailingAddress = x.mailingAddress
            }).ToList();
        }

        public async Task<int> GetCountOfAllBusinessLicenses()
        {
            return await APIDbContext.BusinessLicenses.CountAsync();
        }

        public async Task<int> GetCountOfAllBusinessLicensesWithOnlyMembers()
        {
            return await APIDbContext.BusinessLicenses.Where(x => x.member == true).CountAsync();
        }

        public async Task<D_BusinessLicense> GetBusinessLicense(int licenseId)
        {
            return await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.id == licenseId);
        }

        public async Task<IEnumerable<DTO_BusinessLicense>> GetBusinessLicensesFilterDates(DateTime startEffectiveDate, DateTime cancelEffectiveDate)
        {
            var query = from License in APIDbContext.BusinessLicenses
                        from User in APIDbContext.Users
                        from ZipCode in APIDbContext.ZipCodes
                        where
                            License.userId == User.id &&
                            License.businessCityId == ZipCode.city.id &&
                            License.businessStateId == ZipCode.city.state.id &&
                            License.businessZipCodeId == ZipCode.id &&
                            License.startEffectiveDate >= startEffectiveDate && License.cancelEffectiveDate <= cancelEffectiveDate
                        select new
                        {
                            username = User.name,
                            license = License.name,
                            startEffectiveDate = License.startEffectiveDate,
                            cancelEffectiveDate = License.cancelEffectiveDate,
                            firstName = License.firstName,
                            lastName = License.lastName,
                            businessAddress = License.businessAddress,
                            businessCity = ZipCode.city.name,
                            businessState = ZipCode.city.state.name,
                            businessZipCode = ZipCode.name,
                            dayTimePhone = License.dayTimePhone,
                            mailingAddress = License.mailingAddress
                        };

            var list = await query.ToListAsync().ConfigureAwait(false);

            return list.Select(x => new DTO_BusinessLicense()
            {
                username = x.username,
                license = x.license,
                startEffectiveDate = x.startEffectiveDate,
                cancelEffectiveDate = x.cancelEffectiveDate,
                firstName = x.firstName,
                lastName = x.lastName,
                businessAddress = x.businessAddress,
                businessCity = x.businessCity,
                businessState = x.businessState,
                businessZipCode = x.businessZipCode,
                dayTimePhone = x.dayTimePhone,
                mailingAddress = x.mailingAddress
            }).ToList();
        }

        public async Task<IEnumerable<DTO_BusinessLicense>> GetBusinessLicensesFilterSICCode(int groupOfSICCodesId, int SICCodeId)
        {
            var query = from License in APIDbContext.BusinessLicenses
                        from User in APIDbContext.Users
                        from ZipCode in APIDbContext.ZipCodes
                        where
                            License.userId == User.id &&
                            License.businessCityId == ZipCode.city.id &&
                            License.businessStateId == ZipCode.city.state.id &&
                            License.businessZipCodeId == ZipCode.id &&
                            (
                            License.groupOfSICCodes1Id == groupOfSICCodesId && License.SICCode1Id == SICCodeId ||
                            License.groupOfSICCodes2Id == groupOfSICCodesId && License.SICCode2Id == SICCodeId ||
                            License.groupOfSICCodes3Id == groupOfSICCodesId && License.SICCode3Id == SICCodeId ||
                            License.groupOfSICCodes4Id == groupOfSICCodesId && License.SICCode4Id == SICCodeId
                            )
                        select new
                        {
                            username = User.name,
                            license = License.name,
                            startEffectiveDate = License.startEffectiveDate,
                            cancelEffectiveDate = License.cancelEffectiveDate,
                            firstName = License.firstName,
                            lastName = License.lastName,
                            businessAddress = License.businessAddress,
                            businessCity = ZipCode.city.name,
                            businessState = ZipCode.city.state.name,
                            businessZipCode = ZipCode.name,
                            dayTimePhone = License.dayTimePhone,
                            mailingAddress = License.mailingAddress
                        };

            var list = await query.ToListAsync().ConfigureAwait(false);

            return list.Select(x => new DTO_BusinessLicense()
            {
                username = x.username,
                license = x.license,
                startEffectiveDate = x.startEffectiveDate,
                cancelEffectiveDate = x.cancelEffectiveDate,
                firstName = x.firstName,
                lastName = x.lastName,
                businessAddress = x.businessAddress,
                businessCity = x.businessCity,
                businessState = x.businessState,
                businessZipCode = x.businessZipCode,
                dayTimePhone = x.dayTimePhone,
                mailingAddress = x.mailingAddress
            }).ToList();
        }

        public async Task<int> GetLastBusinessLicenseIdForUser(Guid userId)
        {
            return await APIDbContext.BusinessLicenses.Where(x => x.userId == userId).Select(x => x.id).MaxAsync();
        }

        public async Task<bool> UpdateBusinessLicenseStep2(int licenseId, D_BusinessLicense license)
        {
            var res = await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.id == licenseId);

            if (res == null) return false;

            res.listAllOwnersPartnersOfficers = license.listAllOwnersPartnersOfficers;

            res.name1 = license.name1;
            res.title1 = license.title1;
            res.businessPhone1 = license.businessPhone1;
            res.homePhone1 = license.homePhone1;
            res.homeAddress1 = license.homeAddress1;
            res.city1Id = license.city1Id;
            res.state1Id = license.state1Id;
            res.zipCode1Id = license.zipCode1Id;

            res.name2 = license.name2;
            res.title2 = license.title2;
            res.businessPhone2 = license.businessPhone2;
            res.homePhone2 = license.homePhone2;
            res.homeAddress2 = license.homeAddress2;
            res.city2Id = license.city2Id;
            res.state2Id = license.state2Id;
            res.zipCode2Id = license.zipCode2Id;

            res.name3 = license.name3;
            res.title3 = license.title3;
            res.businessPhone3 = license.businessPhone3;
            res.homePhone3 = license.homePhone3;
            res.homeAddress3 = license.homeAddress3;
            res.city3Id = license.city3Id;
            res.state3Id = license.state3Id;
            res.zipCode3Id = license.zipCode3Id;

            res.name4 = license.name4;
            res.title4 = license.title4;
            res.businessPhone4 = license.businessPhone4;
            res.homePhone4 = license.homePhone4;
            res.homeAddress4 = license.homeAddress4;
            res.city4Id = license.city4Id;
            res.state4Id = license.state4Id;
            res.zipCode4Id = license.zipCode4Id;

            await APIDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBusinessLicenseStep3(int licenseId, D_BusinessLicense license)
        {
            var res = await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.id == licenseId);

            if (res == null) return false;

            res.typeOfLegalOrganization = license.typeOfLegalOrganization;
            res.member = license.member;
            res.percentageIsOwnedBySissetonWahpetonOyateMember = license.percentageIsOwnedBySissetonWahpetonOyateMember;
            res.percentageIsOwnedByAmericanIndians = license.percentageIsOwnedByAmericanIndians;
            res.groupOfSICCodes1Id = license.groupOfSICCodes1Id;
            res.SICCode1Id = license.SICCode1Id;
            res.groupOfSICCodes2Id = license.groupOfSICCodes2Id;
            res.SICCode2Id = license.SICCode2Id;
            res.groupOfSICCodes3Id = license.groupOfSICCodes3Id;
            res.SICCode3Id = license.SICCode3Id;
            res.groupOfSICCodes4Id = license.groupOfSICCodes4Id;
            res.SICCode4Id = license.SICCode4Id;
            res.businessLocated = license.businessLocated;

            await APIDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBusinessLicenseStep4(int licenseId, D_BusinessLicense license)
        {
            var res = await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.id == licenseId);

            if (res == null) return false;

            res.licenseReason = license.licenseReason;
            res.priorOwnerAddress = license.priorOwnerAddress;
            res.priorOwnerCityId = license.priorOwnerCityId;
            res.priorOwnerStateId = license.priorOwnerStateId;
            res.priorOwnerZipCodeId = license.priorOwnerZipCodeId;
            res.currentTribalTaxIDnumber = license.currentTribalTaxIDnumber;
            res.shouldAnyNumberBeCancelled = license.shouldAnyNumberBeCancelled;
            res.cancelEffectiveDate = license.cancelEffectiveDate;

            await APIDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBusinessLicenseStep5(int licenseId, D_BusinessLicense license)
        {
            var res = await APIDbContext.BusinessLicenses.FirstOrDefaultAsync(x => x.id == licenseId);

            if (res == null) return false;

            res.name = license.name;
            res.password = license.password;
            res.secretQuestion = license.secretQuestion;
            res.secretAnswer = license.secretAnswer;
            res.email = license.email;

            await APIDbContext.SaveChangesAsync();
            return true;
        }
    }
}