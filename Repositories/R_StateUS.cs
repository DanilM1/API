using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class R_StateUS : I_StateUS
    {
        private readonly APIDbContext APIDbContext;

        public R_StateUS(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<IEnumerable<D_StateUS>> GetAllStatesUS()
        {
            return await APIDbContext.StatesUS.ToListAsync();
        }
    }
}