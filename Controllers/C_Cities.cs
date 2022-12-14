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
        private readonly I_City I_City;
        private readonly IMapper I_Mapper;

        public C_Cities(I_City I_City, IMapper I_Mapper)
        {
            this.I_City = I_City;
            this.I_Mapper = I_Mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetCities(int stateId)
        {
            return Ok(I_Mapper.Map<List<DTO_City>>(await I_City.GetCities(stateId)));
        }
    }
}