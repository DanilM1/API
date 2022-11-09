using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_Cities : Controller
    {
        private readonly I_City I_City;

        public C_Cities(I_City I_City)
        {
            this.I_City = I_City;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<List<string>> GetListOfAllCitiesOfStateById(string State_id)
        {
            List<string> list = await I_City.GetListOfAllCitiesOfStateById(State_id);
            return list;
        }

        [HttpGet]
        [Route("~/C_City/ZIPs")]
        [Authorize(Roles = "reader")]
        public async Task<List<string>> GetListOfAllZIPs_Filter_StateCity(string State_id, string City)
        {
            List<string> list = await I_City.GetListOfAllZIPs_Filter_StateCity(State_id, City);
            return list;
        }
    }
}