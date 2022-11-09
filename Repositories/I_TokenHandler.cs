using API.Models.Domain;

namespace API.Repositories
{
    public interface I_TokenHandler
    {
        Task<string> CreateToken(D_User User);
    }
}
