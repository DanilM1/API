using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class R_Role : I_Role
    {
        private readonly APIDbContext APIDbContext;

        public R_Role(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<List<string>> GetListOfAllRoles()
        {
            List<string> list = await APIDbContext.Roles.OrderBy(x => x.Role_id).Select(x => x.Role).ToListAsync();
            return list;
        }

        public async Task<D_Role> GetRoleId_Filter_Role(string Role)
        {
            return await APIDbContext.Roles.FirstOrDefaultAsync(x => x.Role == Role);
        }
    }
}