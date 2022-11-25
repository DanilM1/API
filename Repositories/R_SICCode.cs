using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class R_SICCode : I_SICCode
    {
        private readonly APIDbContext APIDbContext;

        public R_SICCode(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<IEnumerable<D_SICCode>> GetSICCodes(int groupOfSICCodesId)
        {
            return await APIDbContext.SICCodes.Where(x => x.groupOfSICCodes.id == groupOfSICCodesId).ToListAsync();
        }
    }
}