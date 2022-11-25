using API.Models.DTO;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_StatesUS : Controller
    {
        private readonly I_StateUS I_StateUS;
        private readonly IMapper I_Mapper;

        public C_StatesUS(I_StateUS I_StateUS, IMapper I_Mapper)
        {
            this.I_StateUS = I_StateUS;
            this.I_Mapper = I_Mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllStatesUS()
        {
            return Ok(I_Mapper.Map<List<DTO_StateUS>>(await I_StateUS.GetAllStatesUS()));
        }
    }
}