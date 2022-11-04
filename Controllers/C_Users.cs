using API.Data;
using API.Models.Domain;
using API.Models.DTO;
using API.Repositories;
using AutoMapper;
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

        private readonly IMapper mapper;

        public C_Users(APIDbContext APIDbContext, I_User user, I_Role role, I_User_Role user_role, I_TokenHandler tokenHandler, IMapper mapper)
        {
            this.APIDbContext = APIDbContext;
            this.user = user;
            this.role = role;
            this.user_role = user_role;
            this.tokenHandler = tokenHandler;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("SignIn")]
        [ActionName("AuthenticateAsync")]
        public async Task<IActionResult> AuthenticateAsync(DTO_SignIn signIn)
        {
            var buf = await user.AuthenticateAsync(signIn.Username, signIn.Password);

            if (buf != null)
            {
                var token = await tokenHandler.CreateTokenAsync(buf);
                return Ok(token);
            }

            return BadRequest("Username or Password is incorrect.");
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> AddAsync(DTO_SignUp signUp)
        {
            if (!await ValidateAddAsync(signUp)) return BadRequest(ModelState);

            var buf1 = new D_User()
            {
                Username = signUp.Username,
                EmailAddress = signUp.EmailAddress,
                Password = signUp.Password,
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Roles = signUp.Roles
            };

            var buf2 = await user.AddAsync(buf1);

            var buf3 = await user.GetAsync();

            foreach (var userRole in signUp.Roles)
            {
                var buf4 = await role.GetAsync(userRole);
                var buf5 = new D_User_Role()
                {
                    UserId = buf3,
                    RoleId = buf4.Role_id
                };
                await user_role.AddAsync(buf5);
            }

            return CreatedAtAction(nameof(AuthenticateAsync), buf2);
        }

        #region Private methods
        private async Task<bool> ValidateAddAsync(DTO_SignUp signUp)
        {
            var user = await APIDbContext.Users.AnyAsync(x => x.Username == signUp.Username || x.EmailAddress == signUp.EmailAddress);

            if (user) ModelState.AddModelError(nameof(signUp.Username), $"{nameof(signUp.Username)} or {nameof(signUp.EmailAddress)} already exists.");

            foreach (var userRole in signUp.Roles)
            {
                var buf = await role.GetAsync(userRole);
                if (buf == null) ModelState.AddModelError(nameof(signUp.Roles), $"{nameof(userRole)} is invalid.");
            }

            if (ModelState.ErrorCount > 0) return false;

            return true;
        }
        #endregion
    }
}