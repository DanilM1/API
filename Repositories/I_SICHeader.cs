namespace API.Repositories
{
    public interface I_SICHeader
    {
        Task<List<string>> GetListOfAllSICHeaders();
    }
}