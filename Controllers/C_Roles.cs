using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_Roles : Controller
    {
        private readonly I_Role I_Role;

        public C_Roles(I_Role I_Role)
        {
            this.I_Role = I_Role;
        }

        [HttpGet]
        public async Task<List<string>> GetListOfAllRoles()
        {
            List<string> list = await I_Role.GetListOfAllRoles();
            return list;
        }
    }
}