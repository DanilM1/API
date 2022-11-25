using API.Models.Domain;

namespace API.Repositories
{
    public interface I_ZipCode
    {
        Task<IEnumerable<D_ZipCode>> GetZipCodes(int cityId);
    }
}