using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class R_GroupOfSICCodes : I_GroupOfSICCodes
    {
        private readonly APIDbContext APIDbContext;

        public R_GroupOfSICCodes(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<IEnumerable<D_GroupOfSICCodes>> GetAllGroupsOfSICCodes()
        {
            return await APIDbContext.GroupsOfSICCodes.ToListAsync();
        }
    }
}