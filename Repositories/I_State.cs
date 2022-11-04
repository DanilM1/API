using API.Models.Domain;

namespace API.Repositories
{
    public interface I_State
    {
        Task<IEnumerable<D_State>> GetAllAsync();
    }
}