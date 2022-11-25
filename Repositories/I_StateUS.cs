using API.Models.Domain;

namespace API.Repositories
{
    public interface I_StateUS
    {
        Task<IEnumerable<D_StateUS>> GetAllStatesUS();
    }
}