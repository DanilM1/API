using API.Models.Domain;

namespace API.Repositories
{
    public interface I_TokenHandler
    {
        Task<string> CreateTokenAsync(D_User User);
    }
}
