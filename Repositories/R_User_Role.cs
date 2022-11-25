using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class R_User_Role : I_User_Role
    {
        private readonly APIDbContext APIDbContext;

        public R_User_Role(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<string> Add_User_Role(D_User_Role User_Role)
        {
            await APIDbContext.Users_Roles.AddAsync(User_Role);
            await APIDbContext.SaveChangesAsync();
            return "Created user with his role(s).";
        }

        public async Task<int> GetMaxRole(Guid userId)
        {
            return await APIDbContext.Users_Roles.Where(x => x.user_id == userId).Select(x => x.role_id).MaxAsync();
        }
    }
}