namespace API.Models.DTO
{
    public class DTO_BusinessLicense
    {
        public string username { get; set; }
        public string license { get; set; }
        public DateTime startEffectiveDate { get; set; }
        public DateTime? cancelEffectiveDate { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string businessAddress { get; set; }
        public string businessCity { get; set; }
        public string businessState { get; set; }
        public string businessZipCode { get; set; }
        public string mailingAddress { get; set; }
        public string dayTimePhone { get; set; }
    }
}