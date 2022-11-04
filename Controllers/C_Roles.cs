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
        private readonly I_Role obj;
        private readonly IMapper mapper;

        public C_Roles(I_Role obj, IMapper mapper)
        {
            this.obj = obj;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(mapper.Map<List<DTO_Role>>(await obj.GetAllAsync()));
        }
    }
}