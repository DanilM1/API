using API.Models.Domain;

namespace API.Repositories
{
    public interface I_User
    {
        Task<D_User> SignIn(string email, string password);
        Task<string> SignUp(D_User user);
        Task<D_User> GetUser(string email);
    }
}