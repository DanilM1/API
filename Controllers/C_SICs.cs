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
        private readonly I_SIC I_SIC;
        private readonly IMapper mapper;

        public C_SICs(I_SIC I_SIC, IMapper mapper)
        {
            this.I_SIC = I_SIC;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetListOfAllSICs_Filter_sGroupCode(string sGroupCode)
        {
            return Ok(mapper.Map<List<DTO_SIC>>(await I_SIC.GetListOfAllSICs_Filter_sGroupCode(sGroupCode)));
        }
    }
}