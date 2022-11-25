using API.Models.Domain;

namespace API.Repositories
{
    public interface I_Role
    {
        Task<IEnumerable<D_Role>> GetAllRoles();
        Task<string> GetRole(int roleId);
    }
}