using API.Models.Domain;

namespace API.Repositories
{
    public interface I_City
    {
        Task<IEnumerable<D_City>> GetCities(int stateId);
    }
}