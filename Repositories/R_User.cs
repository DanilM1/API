using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class R_User : I_User
    {
        private readonly APIDbContext APIDbContext;

        public R_User(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<string> SignUp(D_User User)
        {
            await APIDbContext.Users.AddAsync(User);
            await APIDbContext.SaveChangesAsync();
            return "You have an account.";
        }

        public async Task<D_User> SignIn(string Username, string Password)
        {
            var user = await APIDbContext.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == Username.ToLower() && x.Password == Password);
            if (user == null) return null;

            var userRoles = await APIDbContext.Users_Roles.Where(x => x.UserId == user.User_id).ToListAsync();
            if (userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = await APIDbContext.Roles.FirstOrDefaultAsync(x => x.Role_id == userRole.RoleId);
                    if (role != null) user.Roles.Add(role.Role);
                }
            }
            user.Password = null;
            return user;
        }

        public async Task<D_User> GetUserId_Filter_Username(string Username)
        {
            return await APIDbContext.Users.FirstOrDefaultAsync(x => x.Username == Username);
        }
    }
}