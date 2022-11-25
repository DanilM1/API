namespace API.Models.DTO
{
    public class DTO_BusinessLicenseRegStep4
    {
        public string licenseReason { get; set; }
        public string priorOwnerAddress { get; set; }
        public int? priorOwnerCityId { get; set; } = null;
        public int? priorOwnerStateId { get; set; } = null;
        public int? priorOwnerZipCodeId { get; set; } = null;
        public string currentTribalTaxIDnumber { get; set; }
        public bool shouldAnyNumberBeCancelled { get; set; }
        public DateTime? cancelEffectiveDate { get; set; }
    }
}