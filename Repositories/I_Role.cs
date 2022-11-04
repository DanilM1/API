using API.Models.Domain;

namespace API.Repositories
{
    public interface I_Role
    {
        Task<IEnumerable<D_Role>> GetAllAsync();
        Task<D_Role> GetAsync(string Name);
    }
}