using API.Models.DTO;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_GroupsOfSICCodes : Controller
    {
        private readonly I_GroupOfSICCodes I_SICHeader;
        private readonly IMapper I_Mapper;

        public C_GroupsOfSICCodes(I_GroupOfSICCodes I_SICHeader, IMapper I_Mapper)
        {
            this.I_SICHeader = I_SICHeader;
            this.I_Mapper = I_Mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllGroupsOfSICCodes()
        {
            return Ok(I_Mapper.Map<List<DTO_GroupOfSICCodes>>(await I_SICHeader.GetAllGroupsOfSICCodes()));
        }
    }
}