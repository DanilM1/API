using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class R_City : I_City
    {
        private readonly APIDbContext APIDbContext;

        public R_City(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<IEnumerable<D_City>> GetAllAsync(string State_id)
        {
            return await APIDbContext.Cities.Where(x => x.D_State.State_id == State_id).GroupBy(x => x.City).Select(x => x.First()).ToListAsync();
        }

        public async Task<IEnumerable<D_City>> GetAllAsync2(string State_id, string City)
        {
            return await APIDbContext.Cities.Where(x => x.D_State.State_id == State_id && x.City == City).ToListAsync();
        }
    }
}