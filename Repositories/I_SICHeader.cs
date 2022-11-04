using API.Models.Domain;

namespace API.Repositories
{
    public interface I_SICHeader
    {
        Task<IEnumerable<D_SICHeader>> GetAllAsync();
    }
}