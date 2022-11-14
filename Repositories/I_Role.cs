using API.Models.Domain;

namespace API.Repositories
{
    public interface I_Role
    {
        Task<List<string>> GetListOfAllRoles();
        Task<D_Role> GetRoleId_Filter_Role(string Role);
    }
}