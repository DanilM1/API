using API.Models.Domain;

namespace API.Repositories
{
    public interface I_SICCode
    {
        Task<IEnumerable<D_SICCode>> GetSICCodes(int groupOfSICCodesId);
    }
}