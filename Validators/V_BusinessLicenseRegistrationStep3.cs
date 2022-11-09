using API.Models.DTO;
using FluentValidation;

namespace API.Validators
{
    public class V_BusinessLicenseRegistrationStep3 : AbstractValidator<DTO_BusinessLicenseRegistrationStep3>
    {
        public V_BusinessLicenseRegistrationStep3()
        {
            RuleFor(x => x.iType_LegalOrg).MaximumLength(200);
            RuleFor(x => x.bMember).NotEmpty();
            RuleFor(x => x.iOwned_SWST_Percent).InclusiveBetween(0, 100);
            RuleFor(x => x.iOwned_AmeriIndian_percent).LessThanOrEqualTo(x => 100 - x.iOwned_SWST_Percent);
            RuleFor(x => x.directions_nearest_town).MaximumLength(200);
            RuleFor(x => x.License_id).NotEmpty();
        }
    }
}