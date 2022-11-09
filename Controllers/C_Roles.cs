using API.Models.DTO;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_Roles : Controller
    {
        private readonly I_Role I_Role;
        private readonly IMapper mapper;

        public C_Roles(I_Role I_Role, IMapper mapper)
        {
            this.I_Role = I_Role;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetListOfAllRoles()
        {
            return Ok(mapper.Map<List<DTO_Role>>(await I_Role.GetListOfAllRoles()));
        }
    }
}