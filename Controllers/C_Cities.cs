using API.Models.DTO;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_Cities : Controller
    {
        private readonly I_City obj;
        private readonly IMapper mapper;

        public C_Cities(I_City obj, IMapper mapper)
        {
            this.obj = obj;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllAsync(string State_id)
        {
            return Ok(mapper.Map<List<DTO_City>>(await obj.GetAllAsync(State_id)));
        }

        [HttpGet]
        [Route("~/C_City/ZIPs")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllAsync2(string State_id, string City)
        {
            return Ok(mapper.Map<List<DTO_ZIP>>(await obj.GetAllAsync2(State_id, City)));
        }
    }
}