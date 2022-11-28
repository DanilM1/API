using API.Models.DTO;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_ZipCodes : Controller
    {
        private readonly I_ZipCode I_ZipCode;
        private readonly IMapper I_Mapper;

        public C_ZipCodes(I_ZipCode I_ZipCode, IMapper I_Mapper)
        {
            this.I_ZipCode = I_ZipCode;
            this.I_Mapper = I_Mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetZipCodes(int cityId)
        {
            return Ok(I_Mapper.Map<List<DTO_ZipCode>>(await I_ZipCode.GetZipCodes(cityId)));
        }
    }
}