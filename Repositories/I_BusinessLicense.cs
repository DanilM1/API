using API.Models.Domain;
using API.Models.DTO;

namespace API.Repositories
{
    public interface I_BusinessLicense
    {
        Task<int> GetCountOfAllLicenses();
        Task<int> GetCountOfAllLicensesWithOnlyMembers();
        Task<int> GetLastLicenseIdForUser(Guid userId);
        Task<D_BusinessLicense> GetLicense(int licenseId);
        Task<IEnumerable<DTO_BusinessLicense>> GetAllLicenses();
        Task<IEnumerable<DTO_BusinessLicense>> GetLicensesFilterDates(DateTime startEffectiveDate, DateTime cancelEffectiveDate);
        Task<IEnumerable<DTO_BusinessLicense>> GetLicensesFilterSICCode(int groupOfSICCodesId, int SICCodeId);

        Task<string> AddNewLicense(D_BusinessLicense license);

        Task<string> UpdateLicenseStep2(int licenseId, D_BusinessLicense license);
        Task<string> UpdateLicenseStep3(int licenseId, D_BusinessLicense license);
        Task<string> UpdateLicenseStep4(int licenseId, D_BusinessLicense license);
        Task<string> UpdateLicenseStep5(int licenseId, D_BusinessLicense license);
    }
}