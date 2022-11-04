using API.Models.DTO;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_SICHeaders : Controller
    {
        private readonly I_SICHeader obj;
        private readonly IMapper mapper;

        public C_SICHeaders(I_SICHeader obj, IMapper mapper)
        {
            this.obj = obj;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(mapper.Map<List<DTO_SICHeader>>(await obj.GetAllAsync()));
        }
    }
}