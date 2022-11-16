using API.Models.Domain;

namespace API.Repositories
{
    public interface I_User
    {
        Task<D_User> SignIn(string Username, string Password);
        Task<string> SignUp(D_User User);
        Task<D_User> GetUserId_Filter_Username(string Username);
    }
}