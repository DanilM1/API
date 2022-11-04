using API.Models.Domain;

namespace API.Repositories
{
    public interface I_User
    {
        Task<D_User> AuthenticateAsync(string Username, string Password);
        Task<string> AddAsync(D_User User);
        Task<int> GetAsync();
    }
}