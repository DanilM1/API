using API.Data;
using API.Models.Domain;

namespace API.Repositories
{
    public class R_User_Role : I_User_Role
    {
        private readonly APIDbContext APIDbContext;

        public R_User_Role(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<D_User_Role> AddAsync(D_User_Role d_User_Role)
        {
            await APIDbContext.Users_Roles.AddAsync(d_User_Role);
            await APIDbContext.SaveChangesAsync();
            return d_User_Role;
        }
    }
}