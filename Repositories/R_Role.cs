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

        public async Task<IEnumerable<D_Role>> GetAllRoles()
        {
            return await APIDbContext.Roles.OrderBy(x => x.id).ToListAsync();
        }

        public async Task<string> GetRole(int roleId)
        {
            return await APIDbContext.Roles.Where(x => x.id == roleId).Select(x => x.name).FirstAsync();
        }
    }
}