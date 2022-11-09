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
        private readonly I_State I_State;
        private readonly IMapper mapper;

        public C_States(I_State I_State, IMapper mapper)
        {
            this.I_State = I_State;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetListOfAllStates()
        {
            return Ok(mapper.Map<List<DTO_State>>(await I_State.GetListOfAllStates()));
        }
    }
}