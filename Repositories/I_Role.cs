using API.Models.Domain;

namespace API.Repositories
{
    public interface I_Role
    {
        Task<IEnumerable<D_Role>> GetListOfAllRoles();
        Task<D_Role> GetRoleId_Filter_Name(string Name);
    }
}