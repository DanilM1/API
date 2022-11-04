using API.Models.Domain;

namespace API.Repositories
{
    public interface I_SIC
    {
        Task<IEnumerable<D_SIC>> GetAllAsync(string sGroupCode);
    }
}