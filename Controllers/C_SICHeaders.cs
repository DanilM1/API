using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_SICHeaders : Controller
    {
        private readonly I_SICHeader I_SICHeader;

        public C_SICHeaders(I_SICHeader I_SICHeader)
        {
            this.I_SICHeader = I_SICHeader;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<List<string>> GetListOfAllSICHeaders()
        {
            List<string> list = await I_SICHeader.GetListOfAllSICHeaders();
            return list;
        }
    }
}