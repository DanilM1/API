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
        private readonly IMapper I_Mapper;

        public C_Roles(I_Role I_Role, IMapper I_Mapper)
        {
            this.I_Role = I_Role;
            this.I_Mapper = I_Mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(I_Mapper.Map<List<DTO_Role>>(await I_Role.GetAllRoles()));
        }
    }
}