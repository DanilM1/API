using API.Models.DTO;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_SICCodes : Controller
    {
        private readonly I_SICCode I_SICCode;
        private readonly IMapper I_Mapper;

        public C_SICCodes(I_SICCode I_SICCode, IMapper I_Mapper)
        {
            this.I_SICCode = I_SICCode;
            this.I_Mapper = I_Mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetSICCodes(int groupOfSICCodesId)
        {
            return Ok(I_Mapper.Map<List<DTO_SICCode>>(await I_SICCode.GetSICCodes(groupOfSICCodesId)));
        }
    }
}