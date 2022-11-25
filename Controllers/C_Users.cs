using API.Data;
using API.Models.Domain;
using API.Models.DTO;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using System.Security.Claims;

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
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(DTO_SignUp signUp)
        {
            if (!await ValidateSignUp(signUp)) return BadRequest(ModelState);

            var id = Guid.NewGuid();

            var allRoles = await I_Role.GetAllRoles();

            var roles = new List<string> { };

            foreach (var role in allRoles)
            {
                var user_roles = new D_User_Role()
                {
                    user_id = id,
                    role_id = role.id
                };
                await I_User_Role.Add_User_Role(user_roles);

                roles.Add(role.name);

                if (role.id == signUp.roleId) break;
            }

            var user = new D_User()
            {
                id = id,
                name = signUp.name,
                roles = roles,
                email = signUp.email,
                firstName = signUp.firstName,
                lastName = signUp.lastName,
                password = signUp.password,
            };

            await I_User.SignUp(user);

            var answer = "You have an account.";

            return CreatedAtAction(nameof(SignIn), new JavaScriptSerializer().Serialize(answer));
        }

        [HttpPost]
        [Route("SignIn")]
        [ActionName("SignIn")]
        public async Task<IActionResult> SignIn(DTO_SignIn signIn)
        {
            var user = await I_User.SignIn(signIn.name, signIn.password);

            if (user != null)
            {
                var token = await I_TokenHandler.CreateToken(user);

                var user_ = await I_User.GetUser(User.FindFirst(ClaimTypes.Name)?.Value);

                var role = await I_User_Role.GetMaxRole(user_.id);

                return Ok(new JavaScriptSerializer().Serialize($"Bearer {token}"));
            };

            return BadRequest(new JavaScriptSerializer().Serialize("Username or Password is incorrect."));
        }

        #region Private methods
        private async Task<bool> ValidateSignUp(DTO_SignUp signUp)
        {
            var user = await APIDbContext.Users.AnyAsync(x => x.name == signUp.name || x.email == signUp.email);

            if (user) ModelState.AddModelError(nameof(signUp.name), $"{nameof(signUp.name)} or {nameof(signUp.email)} already exists.");

            var role = await I_Role.GetRole(signUp.roleId);

            if (role == null) ModelState.AddModelError(nameof(signUp.roleId), $"{nameof(signUp.roleId)} is invalid.");

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }
        #endregion
    }
}