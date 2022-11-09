namespace API.Repositories
{
    public interface I_City
    {
        Task<List<string>> GetListOfAllCitiesOfStateById(string State_id);
        Task<List<string>> GetListOfAllZIPs_Filter_StateCity(string State_id, string City);
    }
}