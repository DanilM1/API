using API.Data;
using API.Models.Domain;
using API.Models.DTO;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            foreach (var role in allRoles)
            {
                var user_roles = new D_User_Role()
                {
                    user_id = id,
                    role_id = role.id
                };

                await I_User_Role.Add_User_Role(user_roles);

                if (role.id == signUp.roleId) break;
            }

            return Ok();
        }

        [HttpPost]
        [Route("SignIn")]
        [ActionName("SignIn")]
        public async Task<IActionResult> SignIn(DTO_SignIn signIn)
        {
            var user = await I_User.SignIn(signIn.email, signIn.password);

            if (user != null)
            {
                var token = await I_TokenHandler.CreateToken(user);

                var role = await I_User_Role.GetMaxRole(user.id);

                return Ok(Json(new[] { new { token, role } }));
            }

            return BadRequest(ModelState);
        }

        #region Private methods
        private async Task<bool> ValidateSignUp(DTO_SignUp signUp)
        {
            var user = await APIDbContext.Users.AnyAsync(x => x.email == signUp.email || x.name == signUp.name);

            if (user) ModelState.AddModelError(nameof(signUp.email), $"{nameof(signUp.email)} already exists.");

            var role = await I_Role.GetRole(signUp.roleId);

            if (role == null) ModelState.AddModelError(nameof(signUp.roleId), $"{nameof(signUp.roleId)} is invalid.");

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }
        #endregion
    }
}