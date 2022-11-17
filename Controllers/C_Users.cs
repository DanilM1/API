using API.Data;
using API.Models.Domain;
using API.Models.DTO;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using System.Net.Http.Headers;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class C_Users : Controller
    {
        private readonly APIDbContext APIDbContext;
        private readonly I_User I_User;
        private readonly I_Role I_Role;
        private readonly I_User_Role I_User_Role;
        private readonly I_TokenHandler I_TokenHandler;

        public C_Users(APIDbContext APIDbContext, I_User I_User, I_Role I_Role, I_User_Role I_User_Role, I_TokenHandler I_TokenHandler)
        {
            this.APIDbContext = APIDbContext;
            this.I_User = I_User;
            this.I_Role = I_Role;
            this.I_User_Role = I_User_Role;
            this.I_TokenHandler = I_TokenHandler;
        }

        [HttpPost]
        [Route("SignIn")]
        [ActionName("SignIn")]
        public async Task<IActionResult> SignIn(DTO_SignIn signIn)
        {
            var User = await I_User.SignIn(signIn.Username, signIn.Password);

            if (User != null)
            {
                var token = await I_TokenHandler.CreateToken(User);

                HttpContext.Response.Headers.Add("Authorization", $"Bearer {token}");

                return Ok();
            };

            return BadRequest("Username or Password is incorrect.");
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(DTO_SignUp SignUp)
        {
            if (!await ValidateSignUp(SignUp)) return BadRequest(ModelState);

            var User_id = Guid.NewGuid();

            var ListOfAllRoles = await I_Role.GetListOfAllRoles();

            var Roles = new List<string> { };

            foreach (var Role in ListOfAllRoles)
            {
                Roles.Add(Role);
                if (Role == SignUp.Role) break;
            }

            var buf = new D_User()
            {
                User_id = User_id,
                Username = SignUp.Username,
                EmailAddress = SignUp.EmailAddress,
                Password = SignUp.Password,
                FirstName = SignUp.FirstName,
                LastName = SignUp.LastName,
                Roles = Roles
            };

            await I_User.SignUp(buf);

            foreach (var Role in Roles)
            {
                var Name = await I_Role.GetRoleId_Filter_Role(Role);
                if (Name != null)
                {
                    var User_Roles = new D_User_Role()
                    {
                        UserId = User_id,
                        RoleId = Name.Role_id
                    };
                    await I_User_Role.Add_User_Role(User_Roles);
                }
            }

            var answer = "You have an account.";

            return CreatedAtAction(nameof(SignIn), new JavaScriptSerializer().Serialize(answer));
        }

        #region Private methods
        private async Task<bool> ValidateSignUp(DTO_SignUp SignUp)
        {
            var User = await APIDbContext.Users.AnyAsync(x => x.Username == SignUp.Username || x.EmailAddress == SignUp.EmailAddress);

            if (User) ModelState.AddModelError(nameof(SignUp.Username), $"{nameof(SignUp.Username)} or {nameof(SignUp.EmailAddress)} already exists.");

            var Role = await I_Role.GetRoleId_Filter_Role(SignUp.Role);

            if (Role == null) ModelState.AddModelError(nameof(SignUp.Role), $"{nameof(SignUp.Role)} is invalid.");

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }
        #endregion
    }
}