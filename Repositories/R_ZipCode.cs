using API.Data;
using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class R_ZipCode : I_ZipCode
    {
        private readonly APIDbContext APIDbContext;

        public R_ZipCode(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<IEnumerable<D_ZipCode>> GetZipCodes(int cityId)
        {
            return await APIDbContext.ZipCodes.Where(x => x.city.id == cityId).ToListAsync();
        }
    }
}