using API.Models.Domain;

namespace API.Repositories
{
    public interface I_City
    {
        Task<IEnumerable<D_City>> GetAllAsync(string State_id);
        Task<IEnumerable<D_City>> GetAllAsync2(string State_id, string City);
    }
}
