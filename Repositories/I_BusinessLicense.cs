using API.Models.Domain;

namespace API.Repositories
{
    public interface I_BusinessLicense
    {
        Task<IEnumerable<D_BusinessLicense>> GetAllAsync();
        Task<int> GetAsync();
        Task<D_BusinessLicense> GetMemberAsync(int iTemp_id);
        Task<int> GetMembersAsync();
        Task<int> GetAllCountAsync();
        Task<IEnumerable<D_BusinessLicense>> GetAllDatesAsync(DateTime dStartDate, DateTime dEndDate);
        Task<IEnumerable<D_BusinessLicense>> GetAllSICsAsync(string SICHeader, int SIC);
        Task<string> AddAsync(D_BusinessLicense D_BusinessLicense);
        Task<string> UpdateAsync2(int iTemp_id, D_BusinessLicense D_BusinessLicense);
        Task<string> UpdateAsync3(int iTemp_id, D_BusinessLicense D_BusinessLicense);
        Task<string> UpdateAsync4(int iTemp_id, D_BusinessLicense D_BusinessLicense);
        Task<string> UpdateAsync5(int iTemp_id, D_BusinessLicense D_BusinessLicense);
    }
}