using API.Models.Domain;
using API.Models.DTO;

namespace API.Repositories
{
    public interface I_BusinessLicense
    {
        Task<int> GetCountOfAllBusinessLicenses();
        Task<int> GetCountOfAllBusinessLicensesWithOnlyMembers();
        Task<int> GetLastBusinessLicenseIdForUser(Guid userId);
        Task<D_BusinessLicense> GetBusinessLicense(int licenseId);
        Task<IEnumerable<DTO_BusinessLicense>> GetAllBusinessLicenses();
        Task<IEnumerable<DTO_BusinessLicense>> GetBusinessLicensesFilterDates(DateTime startEffectiveDate, DateTime cancelEffectiveDate);
        Task<IEnumerable<DTO_BusinessLicense>> GetBusinessLicensesFilterSICCode(int groupOfSICCodesId, int SICCodeId);

        Task<string> AddNewBusinessLicense(D_BusinessLicense license);

        Task<string> UpdateBusinessLicenseStep2(int licenseId, D_BusinessLicense license);
        Task<string> UpdateBusinessLicenseStep3(int licenseId, D_BusinessLicense license);
        Task<string> UpdateBusinessLicenseStep4(int licenseId, D_BusinessLicense license);
        Task<string> UpdateBusinessLicenseStep5(int licenseId, D_BusinessLicense license);
    }
}