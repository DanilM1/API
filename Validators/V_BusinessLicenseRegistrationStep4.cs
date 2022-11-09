using API.Models.DTO;
using FluentValidation;

namespace API.Validators
{
    public class V_BusinessLicenseRegistrationStep4 : AbstractValidator<DTO_BusinessLicenseRegistrationStep4>
    {
        public V_BusinessLicenseRegistrationStep4()
        {
            RuleFor(x => x.iReason_License).MaximumLength(200);
            RuleFor(x => x.prior_owner_Name).MaximumLength(200);
            RuleFor(x => x.prior_owner_Title).MaximumLength(200);
            RuleFor(x => x.prior_owner_BusinessPhone).Matches(@"^[0-9]{5}-[0-9]{3}-[0-9]{4}|$");
            RuleFor(x => x.prior_owner_HomePhone).Matches(@"^[0-9]{5}-[0-9]{3}-[0-9]{4}|$");
            RuleFor(x => x.prior_owner_HomeAddress).MaximumLength(200);
            RuleFor(x => x.sCTT_Id_Current).MaximumLength(200);
            RuleFor(x => x.License_id).NotEmpty();
        }
    }
}