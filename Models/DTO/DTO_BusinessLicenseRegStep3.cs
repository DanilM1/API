namespace API.Models.DTO
{
    public class DTO_BusinessLicenseRegStep3
    {
        public string typeOfLegalOrganization { get; set; }
        public bool member { get; set; }
        public float percentageIsOwnedBySissetonWahpetonOyateMember { get; set; }
        public float percentageIsOwnedByAmericanIndians { get; set; }
        public int? groupOfSICCodes1Id { get; set; } = null;
        public int? SICCode1Id { get; set; } = null;
        public int? groupOfSICCodes2Id { get; set; } = null;
        public int? SICCode2Id { get; set; } = null;
        public int? groupOfSICCodes3Id { get; set; } = null;
        public int? SICCode3Id { get; set; } = null;
        public int? groupOfSICCodes4Id { get; set; } = null;
        public int? SICCode4Id { get; set; } = null;
        public string businessLocated { get; set; }
    }
}