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
        private readonly I_User user;
        private readonly I_Role role;
        private readonly I_User_Role user_role;
        private readonly I_TokenHandler tokenHandler;

        public C_Users(APIDbContext APIDbContext, I_User user, I_Role role, I_User_Role user_role, I_TokenHandler tokenHandler)
        {
            this.APIDbContext = APIDbContext;
            this.user = user;
            this.role = role;
            this.user_role = user_role;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("SignIn")]
        [ActionName("SignIn")]
        public async Task<IActionResult> SignIn(DTO_SignIn signIn)
        {
            var buf = await user.SignIn(signIn.Username, signIn.Password);

            if (buf != null)
            {
                var token = await tokenHandler.CreateToken(buf);
                return Ok(token);
            }

            return BadRequest("Username or Password is incorrect.");
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(DTO_SignUp SignUp)
        {
            if (!await ValidateSignUp(SignUp)) return BadRequest(ModelState);

            var User_id = Guid.NewGuid();

            var buf = new D_User()
            {
                User_id = User_id,
                Username = SignUp.Username,
                EmailAddress = SignUp.EmailAddress,
                Password = SignUp.Password,
                FirstName = SignUp.FirstName,
                LastName = SignUp.LastName,
                Roles = SignUp.Roles
            };

            await user.SignUp(buf);

            foreach (var Name in buf.Roles)
            {
                var Role = await role.GetRoleId_Filter_Name(Name);
                if (Role != null)
                {
                    var User_Roles = new D_User_Role()
                    {
                        UserId = User_id,
                        RoleId = Role.Role_id
                    };
                    await user_role.Add_User_Role(User_Roles);
                }
            }

            return CreatedAtAction(nameof(SignIn), buf.User_id);
        }

        #region Private methods
        private async Task<bool> ValidateSignUp(DTO_SignUp SignUp)
        {
            var user = await APIDbContext.Users.AnyAsync(x => x.Username == SignUp.Username || x.EmailAddress == SignUp.EmailAddress);

            if (user) ModelState.AddModelError(nameof(SignUp.Username), $"{nameof(SignUp.Username)} or {nameof(SignUp.EmailAddress)} already exists.");

            foreach (var Name in SignUp.Roles)
            {
                var Role = await role.GetRoleId_Filter_Name(Name);
                if (Role == null) ModelState.AddModelError(nameof(SignUp.Roles), $"{nameof(Name)} is invalid.");
            }

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }
        #endregion
    }
}