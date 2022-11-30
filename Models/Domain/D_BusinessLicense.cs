using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Domain
{
    public class D_BusinessLicense
    {
        // step 1

        [Key]
        public int id { get; set; }

        [Required]
        public Guid userId { get; set; }

        [Required]
        [MaxLength(100)]
        public string businessName { get; set; }

        [Required]
        [MaxLength(50)]
        public string firstName { get; set; }

        [MaxLength(5)]
        public string? middleInitial { get; set; }

        [Required]
        [MaxLength(50)]
        public string lastName { get; set; }

        [MaxLength(200)]
        public string? businessTradeName { get; set; }

        [Required]
        [MaxLength(9)]
        public string ID_SSN { get; set; }

        [Required]
        [MaxLength(200)]
        public string businessAddress { get; set; }

        [Required]
        public int businessCityId { get; set; }

        [Required]
        public int businessStateId { get; set; }

        [Required]
        public int businessZipCodeId { get; set; }

        [MaxLength(200)]
        public string? mailingAddress { get; set; }

        public int? mailingCityId { get; set; }

        public int? mailingStateId { get; set; }

        public int? mailingZipCodeId { get; set; }

        [Required]
        [MaxLength(14)]
        public string dayTimePhone { get; set; }

        [MaxLength(14)]
        public string? otherPhone { get; set; }

        [MaxLength(14)]
        public string? fax { get; set; }

        [Required]
        public DateTime startEffectiveDate { get; set; }

        // step 2

        [MaxLength(200)]
        public string? listAllOwnersPartnersOfficers { get; set; }

        [MaxLength(100)]
        public string? name1 { get; set; }

        [MaxLength(100)]
        public string? title1 { get; set; }

        [MaxLength(14)]
        public string? businessPhone1 { get; set; }

        [MaxLength(14)]
        public string? homePhone1 { get; set; }

        [MaxLength(200)]
        public string? homeAddress1 { get; set; }

        public int? city1Id { get; set; }

        public int? state1Id { get; set; }

        public int? zipCode1Id { get; set; }

        [MaxLength(100)]
        public string? name2 { get; set; }

        [MaxLength(100)]
        public string? title2 { get; set; }

        [MaxLength(14)]
        public string? businessPhone2 { get; set; }

        [MaxLength(14)]
        public string? homePhone2 { get; set; }

        [MaxLength(200)]
        public string? homeAddress2 { get; set; }

        public int? city2Id { get; set; }

        public int? state2Id { get; set; }

        public int? zipCode2Id { get; set; }

        [MaxLength(100)]
        public string? name3 { get; set; }

        [MaxLength(100)]
        public string? title3 { get; set; }

        [MaxLength(14)]
        public string? businessPhone3 { get; set; }

        [MaxLength(14)]
        public string? homePhone3 { get; set; }

        [MaxLength(200)]
        public string? homeAddress3 { get; set; }

        public int? city3Id { get; set; }

        public int? state3Id { get; set; }

        public int? zipCode3Id { get; set; }

        [MaxLength(100)]
        public string? name4 { get; set; }

        [MaxLength(100)]
        public string? title4 { get; set; }

        [MaxLength(14)]
        public string? businessPhone4 { get; set; }

        [MaxLength(14)]
        public string? homePhone4 { get; set; }

        [MaxLength(200)]
        public string? homeAddress4 { get; set; }

        public int? city4Id { get; set; }

        public int? state4Id { get; set; }

        public int? zipCode4Id { get; set; }

        // step 3

        [MaxLength(200)]
        public string? typeOfLegalOrganization { get; set; }

        public bool? member { get; set; }

        public float? percentageIsOwnedBySissetonWahpetonOyateMember { get; set; }

        public float? percentageIsOwnedByAmericanIndians { get; set; }

        public int? groupOfSICCodes1Id { get; set; }

        public int? SICCode1Id { get; set; }

        public int? groupOfSICCodes2Id { get; set; }

        public int? SICCode2Id { get; set; }

        public int? groupOfSICCodes3Id { get; set; }

        public int? SICCode3Id { get; set; }

        public int? groupOfSICCodes4Id { get; set; }

        public int? SICCode4Id { get; set; }

        [MaxLength(200)]
        public string? businessLocated { get; set; }

        // step 4

        [MaxLength(200)]
        public string? licenseReason { get; set; }

        [MaxLength(200)]
        public string? priorOwnerAddress { get; set; }

        public int? priorOwnerCityId { get; set; }

        public int? priorOwnerStateId { get; set; }

        public int? priorOwnerZipCodeId { get; set; }

        [MaxLength(200)]
        public string? currentTribalTaxIDnumber { get; set; }

        public bool? shouldAnyNumberBeCancelled { get; set; }

        public DateTime? cancelEffectiveDate { get; set; }

        // step 5

        [MaxLength(8)]
        public string? name { get; set; }

        [MaxLength(24)]
        public string? password { get; set; }

        [MaxLength(200)]
        public string? secretQuestion { get; set; }

        [MaxLength(24)]
        public string? secretAnswer { get; set; }

        [MaxLength(254)]
        public string? email { get; set; }
    }
}