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

        public async Task<string> Add_User_Role(D_User_Role User_Role)
        {
            await APIDbContext.Users_Roles.AddAsync(User_Role);
            await APIDbContext.SaveChangesAsync();
            return "Created user with his role(s).";
        }
    }
}