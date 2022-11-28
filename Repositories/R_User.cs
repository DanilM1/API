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

        public async Task<string> SignUp(D_User user)
        {
            await APIDbContext.Users.AddAsync(user);
            await APIDbContext.SaveChangesAsync();
            return "You have an account.";
        }

        public async Task<D_User> SignIn(string email, string password)
        {
            var user = await APIDbContext.Users.FirstOrDefaultAsync(x => x.email.ToLower() == email.ToLower() && x.password == password);
            
            if (user == null) return null;

            var userRoles = await APIDbContext.Users_Roles.Where(x => x.user_id == user.id).ToListAsync();
            if (userRoles.Any())
            {
                user.roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = await APIDbContext.Roles.FirstOrDefaultAsync(x => x.id == userRole.role_id);
                    if (role != null) user.roles.Add(role.name);
                }
            }
            user.password = "";
            return user;
        }

        public async Task<D_User> GetUser(string email)
        {
            return await APIDbContext.Users.FirstOrDefaultAsync(x => x.email == email);
        }
    }
}