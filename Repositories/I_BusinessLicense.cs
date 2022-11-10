using API.Models.Domain;

namespace API.Repositories
{
    public interface I_BusinessLicense
    {
        Task<int> GetCountOfAllLicenses();
        Task<int> GetCountOfAllLicensesWithOnlyMembers();
        Task<int> GetMaxIdOftLicense_Filter_Vendor(Guid vendorUser_Id);
        Task<IEnumerable<D_BusinessLicense>> GetListOfAllLicenses();
        Task<IEnumerable<D_BusinessLicense>> GetListOfAllLicenses_Filter_Dates(DateTime applicationDate, DateTime dCTT_Id_CancelEff);
        Task<IEnumerable<D_BusinessLicense>> GetListOfAllLicenses_Filter_SICs(string sGroupCode, int sSICCode);

        Task<string> AddNewLicense(D_BusinessLicense License);

        Task<string> UpdateLicenseByIdStep2(int License_id, D_BusinessLicense License);
        Task<string> UpdateLicenseByIdStep3(int License_id, D_BusinessLicense License);
        Task<string> UpdateLicenseByIdStep4(int License_id, D_BusinessLicense License);
        Task<string> UpdateLicenseByIdStep5(int License_id, D_BusinessLicense License);
    }
}