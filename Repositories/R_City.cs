using API.Data;
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

        public async Task<List<string>> GetListOfAllCitiesOfStateById(string State_id)
        {
            List<string> list = await APIDbContext.Cities.Where(x => x.D_State.State_id == State_id).Select(x => x.City).Distinct().ToListAsync();
            return list;
        }

        public async Task<List<string>> GetListOfAllZIPs_Filter_StateCity(string State_id, string City)
        {
            List<string> list = await APIDbContext.Cities.Where(x => x.D_State.State_id == State_id && x.City == City).Select(x => x.ZIP).ToListAsync();
            return list;
        }
    }
}