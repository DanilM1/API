using API.Models.DTO;
using FluentValidation;

namespace API.Validators
{
    public class RegularExpressions
    {
        public string password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d~`!@#$%^&*()_\-+=|\\{[}\]:;'<,>.?/]{8,24}$";
        public string ID_SSN = @"^[0-9]{9,9}$";
        public string phoneRequired = @"^[0-9]{5}-[0-9]{3}-[0-9]{4}$";
        public string phoneOrEmpty = @"^[0-9]{5}-[0-9]{3}-[0-9]{4}|$";
    }

    public class V_SignUp : AbstractValidator<DTO_SignUp>
    {
        private RegularExpressions reg = new();

        public V_SignUp()
        {
            RuleFor(x => x.name).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.roleId).NotEmpty();
            RuleFor(x => x.email).NotEmpty().MaximumLength(254).EmailAddress();
            RuleFor(x => x.firstName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.lastName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.password).Matches(reg.password);
        }
    }

    public class SignIn : AbstractValidator<DTO_SignIn>
    {
        private RegularExpressions reg = new();

        public SignIn()
        {
            RuleFor(x => x.email).NotEmpty().MaximumLength(254).EmailAddress();
            RuleFor(x => x.password).Matches(reg.password);
        }
    }

    public class V_BusinessLicenseRegistrationStep1 : AbstractValidator<DTO_BusinessLicenseRegStep1>
    {
        private RegularExpressions reg = new();

        public V_BusinessLicenseRegistrationStep1()
        {
            RuleFor(x => x.businessName).NotEmpty().MinimumLength(3).MaximumLength(200);
            RuleFor(x => x.firstName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.middleInitial).MaximumLength(5);
            RuleFor(x => x.lastName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.businessTradeName).MaximumLength(200);
            RuleFor(x => x.ID_SSN).Matches(reg.ID_SSN);
            RuleFor(x => x.businessAddress).NotEmpty().MinimumLength(3).MaximumLength(200);
            RuleFor(x => x.businessCityId).NotEmpty();
            RuleFor(x => x.businessStateId).NotEmpty();
            RuleFor(x => x.businessZipCodeId).NotEmpty();
            RuleFor(x => x.mailingAddress).MaximumLength(200);
            RuleFor(x => x.dayTimePhone).Matches(reg.phoneRequired);
            RuleFor(x => x.otherPhone).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.fax).Matches(reg.phoneOrEmpty);
        }
    }

    public class V_BusinessLicenseRegistrationStep2 : AbstractValidator<DTO_BusinessLicenseRegStep2>
    {
        private RegularExpressions reg = new();

        public V_BusinessLicenseRegistrationStep2()
        {
            RuleFor(x => x.listAllOwnersPartnersOfficers).MaximumLength(200);

            RuleFor(x => x.name1).MaximumLength(100);
            RuleFor(x => x.title1).MaximumLength(100);
            RuleFor(x => x.businessPhone1).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.homePhone1).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.homeAddress1).MaximumLength(200);

            RuleFor(x => x.name2).MaximumLength(100);
            RuleFor(x => x.title2).MaximumLength(100);
            RuleFor(x => x.businessPhone2).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.homePhone2).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.homeAddress2).MaximumLength(200);

            RuleFor(x => x.name3).MaximumLength(100);
            RuleFor(x => x.title3).MaximumLength(100);
            RuleFor(x => x.businessPhone3).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.homePhone3).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.homeAddress3).MaximumLength(200);

            RuleFor(x => x.name4).MaximumLength(100);
            RuleFor(x => x.title4).MaximumLength(100);
            RuleFor(x => x.businessPhone4).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.homePhone4).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.homeAddress4).MaximumLength(200);
        }
    }

    public class V_BusinessLicenseRegistrationStep3 : AbstractValidator<DTO_BusinessLicenseRegStep3>
    {
        public V_BusinessLicenseRegistrationStep3()
        {
            RuleFor(x => x.typeOfLegalOrganization).MaximumLength(200);
            RuleFor(x => x.member).NotNull();
            RuleFor(x => x.percentageIsOwnedBySissetonWahpetonOyateMember).InclusiveBetween(0, 100).When(x => x.member == true);
            RuleFor(x => x.percentageIsOwnedByAmericanIndians).LessThanOrEqualTo(x => 100 - x.percentageIsOwnedBySissetonWahpetonOyateMember).When(x => x.member == true);
            RuleFor(x => x.businessLocated).MaximumLength(200);
        }
    }

    public class V_BusinessLicenseRegistrationStep4 : AbstractValidator<DTO_BusinessLicenseRegStep4>
    {
        private RegularExpressions reg = new();

        public V_BusinessLicenseRegistrationStep4()
        {
            RuleFor(x => x.licenseReason).MaximumLength(200);
            RuleFor(x => x.priorOwnerAddress).MaximumLength(200);
            RuleFor(x => x.currentTribalTaxIDnumber).MaximumLength(200);
            RuleFor(x => x.shouldAnyNumberBeCancelled).NotNull();
            RuleFor(x => x.cancelEffectiveDate).Must(x => x == null || x.GetType() == typeof(DateTime) && x > default(DateTime));
        }
    }

    public class V_BusinessLicenseRegistrationStep5 : AbstractValidator<DTO_BusinessLicenseRegStep5>
    {
        private RegularExpressions reg = new();

        public V_BusinessLicenseRegistrationStep5()
        {
            RuleFor(x => x.password).Matches(reg.password);
            RuleFor(x => x.secretQuestion).MaximumLength(200);
            RuleFor(x => x.secretAnswer).MaximumLength(24);
            RuleFor(x => x.email).MaximumLength(254).EmailAddress();
        }
    }
}