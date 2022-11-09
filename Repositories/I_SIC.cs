using API.Models.Domain;

namespace API.Repositories
{
    public interface I_SIC
    {
        Task<IEnumerable<D_SIC>> GetListOfAllSICs_Filter_sGroupCode(string sGroupCode);
    }
}