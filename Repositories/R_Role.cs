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

        public async Task<IEnumerable<D_Role>> GetAllAsync()
        {
            return await APIDbContext.Roles.ToListAsync();
        }

        public async Task<D_Role> GetAsync(string Name)
        {
            return await APIDbContext.Roles.FirstOrDefaultAsync(x => x.Name == Name);
        }
    }
}