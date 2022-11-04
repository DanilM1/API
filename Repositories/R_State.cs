using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class R_State : I_State
    {
        private readonly APIDbContext APIDbContext;

        public R_State(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<IEnumerable<D_State>> GetAllAsync()
        {
            return await APIDbContext.States.ToListAsync();
        }
    }
}