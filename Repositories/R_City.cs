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

        public async Task<IEnumerable<D_City>> GetCities(int stateId)
        {
            return await APIDbContext.Cities.Where(x => x.state.id == stateId).Distinct().ToListAsync();
        }
    }
}