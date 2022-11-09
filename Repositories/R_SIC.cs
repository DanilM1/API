using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class R_SIC : I_SIC
    {
        private readonly APIDbContext APIDbContext;

        public R_SIC(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }
        
        public async Task<IEnumerable<D_SIC>> GetListOfAllSICs_Filter_sGroupCode(string sGroupCode)
        {
            return await APIDbContext.SICs.Where(x => x.D_SICHeader.sGroupCode == sGroupCode).ToListAsync();
        }
    }
}