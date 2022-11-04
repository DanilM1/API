using API.Models.DTO;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_States : Controller
    {
        private readonly I_State obj;
        private readonly IMapper mapper;

        public C_States(I_State obj, IMapper mapper)
        {
            this.obj = obj;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(mapper.Map<List<DTO_State>>(await obj.GetAllAsync()));
        }
    }
}