using API.Models.Domain;

namespace API.Repositories
{
    public interface I_User_Role
    {
        Task<bool> Add_User_Role(D_User_Role user_role);
        Task<int> GetMaxRole(Guid userId);
    }
}