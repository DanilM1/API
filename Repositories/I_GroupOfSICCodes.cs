using API.Models.Domain;

namespace API.Repositories
{
    public interface I_GroupOfSICCodes
    {
        Task<IEnumerable<D_GroupOfSICCodes>> GetAllGroupsOfSICCodes();
    }
}