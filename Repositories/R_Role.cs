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
            List<string> list = await APIDbContext.Roles.Select(x => x.Name).ToListAsync();
            return list;
        }

        public async Task<D_Role> GetRoleId_Filter_Name(string Name)
        {
            return await APIDbContext.Roles.FirstOrDefaultAsync(x => x.Name == Name);
        }
    }
}