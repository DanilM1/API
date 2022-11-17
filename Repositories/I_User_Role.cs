using API.Models.Domain;

namespace API.Repositories
{
    public interface I_User_Role
    {
        Task<string> Add_User_Role(D_User_Role User_Role);
        Task<int> GetMaxIdOfRoles_Filter_UserId(Guid UserId);
    }
}