using API.Models.DTO;
using FluentValidation;

namespace API.Validators
{
    public class V_BusinessLicenseRegistrationStep5 : AbstractValidator<DTO_BusinessLicenseRegistrationStep5>
    {
        public V_BusinessLicenseRegistrationStep5()
        {
            RuleFor(x => x.sPwd).NotEmpty().Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*])[0-9a-zA-Z!@#$%^&*]{8,24}$");
            RuleFor(x => x.secretQuestion).MaximumLength(200);
            RuleFor(x => x.secretAnswer).MaximumLength(200);
            RuleFor(x => x.sEmail).MaximumLength(254).EmailAddress();
            RuleFor(x => x.License_id).NotEmpty();
        }
    }
}