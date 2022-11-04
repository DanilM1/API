using API.Models.DTO;
using FluentValidation;

namespace API.Validators
{
    public class V_BusinessLicenseRegistrationStep1 : AbstractValidator<DTO_BusinessLicenseRegistrationStep1>
    {
        public V_BusinessLicenseRegistrationStep1()
        {
            RuleFor(x => x.sBusinessname_Legal).NotEmpty().MinimumLength(3).MaximumLength(200);
            RuleFor(x => x.sName_First_Soleproprietor).NotEmpty().MaximumLength(200);
            RuleFor(x => x.sName_Mi_Soleproprietor).MaximumLength(5);
            RuleFor(x => x.sName_Last_Soleproprietor).NotEmpty().MinimumLength(3).MaximumLength(200);
            RuleFor(x => x.sBusinessName_trade).MinimumLength(3).MaximumLength(200);
            RuleFor(x => x.sFIDSSN).NotEmpty().MinimumLength(12).MaximumLength(12);
            RuleFor(x => x.sBusiness_Address).NotEmpty().MinimumLength(3).MaximumLength(200);
            RuleFor(x => x.sBusiness_City).NotEmpty();
            RuleFor(x => x.sBusiness_State).NotEmpty();
            RuleFor(x => x.sBusiness_Zip).NotEmpty();
            RuleFor(x => x.sMailing_Address).MinimumLength(3).MaximumLength(200);
            RuleFor(x => x.sPhoneNo_DayTime).NotEmpty().Matches(@"^[0-9]{5}-[0-9]{3}-[0-9]{4}$");
            RuleFor(x => x.sPhoneNo_Other).Matches(@"^[0-9]{5}-[0-9]{3}-[0-9]{4}$");
            RuleFor(x => x.sFaxNo).Matches(@"^[0-9]{5}-[0-9]{3}-[0-9]{4}$");
        }
    }
}