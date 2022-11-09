using API.Models.DTO;
using FluentValidation;

namespace API.Validators
{
    public class V_BusinessLicenseRegistrationStep2 : AbstractValidator<DTO_BusinessLicenseRegistrationStep2>
    {
        public V_BusinessLicenseRegistrationStep2()
        {
            RuleFor(x => x.sOPO1_Name).MaximumLength(200);
            RuleFor(x => x.sOPO1_Title).MaximumLength(200);
            RuleFor(x => x.sOPO1_BusinessPhone).Matches(@"^[0-9]{5}-[0-9]{3}-[0-9]{4}|$");
            RuleFor(x => x.sOPO1_HomePhone).Matches(@"^[0-9]{5}-[0-9]{3}-[0-9]{4}|$");
            RuleFor(x => x.sOPO1_HomeAddress).MaximumLength(200);

            RuleFor(x => x.sOPO2_Name).MaximumLength(200);
            RuleFor(x => x.sOPO2_Title).MaximumLength(200);
            RuleFor(x => x.sOPO2_BusinessPhone).Matches(@"^[0-9]{5}-[0-9]{3}-[0-9]{4}|$");
            RuleFor(x => x.sOPO2_HomePhone).Matches(@"^[0-9]{5}-[0-9]{3}-[0-9]{4}|$");
            RuleFor(x => x.sOPO2_HomeAddress).MaximumLength(200);

            RuleFor(x => x.sOPO3_Name).MaximumLength(200);
            RuleFor(x => x.sOPO3_Title).MaximumLength(200);
            RuleFor(x => x.sOPO3_BusinessPhone).Matches(@"^[0-9]{5}-[0-9]{3}-[0-9]{4}|$");
            RuleFor(x => x.sOPO3_HomePhone).Matches(@"^[0-9]{5}-[0-9]{3}-[0-9]{4}|$");
            RuleFor(x => x.sOPO3_HomeAddress).MaximumLength(200);

            RuleFor(x => x.License_id).NotEmpty();
        }
    }
}