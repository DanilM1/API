using API.Models.DTO;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_SICs : Controller
    {
        private readonly I_SIC obj;
        private readonly IMapper mapper;

        public C_SICs(I_SIC obj, IMapper mapper)
        {
            this.obj = obj;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllAsync(string sGroupCode)
        {
            return Ok(mapper.Map<List<DTO_SIC>>(await obj.GetAllAsync(sGroupCode)));
        }
    }
}