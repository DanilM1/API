using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class R_SICHeader : I_SICHeader
    {
        private readonly APIDbContext APIDbContext;

        public R_SICHeader(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<IEnumerable<D_SICHeader>> GetAllAsync()
        {
            return await APIDbContext.SICHeaders.ToListAsync();
        }
    }
}