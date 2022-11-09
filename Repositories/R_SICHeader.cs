using API.Data;
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

        public async Task<List<string>> GetListOfAllSICHeaders()
        {
            List<string> list = await APIDbContext.SICHeaders.Select(x => x.sGroupCode).ToListAsync();
            return list;
        }
    }
}