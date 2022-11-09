using API.Models.Domain;

namespace API.Repositories
{
    public interface I_User
    {
        Task<D_User> SignIn(string Username, string Password);
        Task<Guid> SignUp(D_User User);
    }
}