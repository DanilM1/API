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
        private readonly I_SICHeader I_SICHeader;
        private readonly IMapper mapper;

        public C_SICHeaders(I_SICHeader I_SICHeader, IMapper mapper)
        {
            this.I_SICHeader = I_SICHeader;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<List<string>> GetListOfAllSICHeaders()
        {
            List<string> list = await I_SICHeader.GetListOfAllSICHeaders();
            return list;
        }
    }
}