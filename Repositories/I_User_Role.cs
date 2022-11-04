using API.Models.Domain;

namespace API.Repositories
{
    public interface I_User_Role
    {
        Task<D_User_Role> AddAsync(D_User_Role d_User_Role);
    }
}