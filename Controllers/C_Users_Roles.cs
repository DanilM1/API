using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_Users_Roles : Controller
    {
        private readonly I_User I_User;
        private readonly I_User_Role I_User_Role;

        public C_Users_Roles(I_User I_User, I_User_Role I_User_Role)
        {
            this.I_User = I_User;
            this.I_User_Role = I_User_Role;
        }

        [HttpGet]
        [Route("~/C_GetMaxIdOfRoles_Filter_Username")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetMaxIdOfRoles_Filter_UserId()
        {
            var user = await I_User.GetUserId_Filter_Username(User.FindFirst(ClaimTypes.Name)?.Value);
            
            return Ok(await I_User_Role.GetMaxIdOfRoles_Filter_UserId(user.User_id));
        }
    }
}