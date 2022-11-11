using API.Models.DTO;
using FluentValidation;

namespace API.Validators
{
    public class RegularExpressions
    {
        public string password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d~`!@#$%^&*()_\-+=|\\{[}\]:;'<,>.?/]{8,24}$";
        public string phoneRequired = @"^[0-9]{5}-[0-9]{3}-[0-9]{4}$";
        public string phoneOrEmpty = @"^[0-9]{5}-[0-9]{3}-[0-9]{4}|$";
    }

    public class V_SignUp : AbstractValidator<DTO_SignUp>
    {
        private RegularExpressions reg = new();

        public V_SignUp()
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.EmailAddress).NotEmpty().MaximumLength(254).EmailAddress();
            RuleFor(x => x.Password).Matches(reg.password);
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(30);
        }
    }

    public class SignIn : AbstractValidator<DTO_SignIn>
    {
        private RegularExpressions reg = new();

        public SignIn()
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.Password).Matches(reg.password);
        }
    }

    public class V_BusinessLicenseRegistrationStep1 : AbstractValidator<DTO_BusinessLicenseRegistrationStep1>
    {
        private RegularExpressions reg = new();

        public V_BusinessLicenseRegistrationStep1()
        {
            RuleFor(x => x.vendorUser_Id).NotEmpty();
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
            RuleFor(x => x.sMailing_Address).MaximumLength(254).EmailAddress();
            RuleFor(x => x.sPhoneNo_DayTime).Matches(reg.phoneRequired);
            RuleFor(x => x.sPhoneNo_Other).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.sFaxNo).Matches(reg.phoneOrEmpty);
        }
    }

    public class V_BusinessLicenseRegistrationStep2 : AbstractValidator<DTO_BusinessLicenseRegistrationStep2>
    {
        private RegularExpressions reg = new();

        public V_BusinessLicenseRegistrationStep2()
        {
            RuleFor(x => x.sOPO1_Name).MaximumLength(200);
            RuleFor(x => x.sOPO1_Title).MaximumLength(200);
            RuleFor(x => x.sOPO1_BusinessPhone).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.sOPO1_HomePhone).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.sOPO1_HomeAddress).MaximumLength(200);

            RuleFor(x => x.sOPO2_Name).MaximumLength(200);
            RuleFor(x => x.sOPO2_Title).MaximumLength(200);
            RuleFor(x => x.sOPO2_BusinessPhone).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.sOPO2_HomePhone).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.sOPO2_HomeAddress).MaximumLength(200);

            RuleFor(x => x.sOPO3_Name).MaximumLength(200);
            RuleFor(x => x.sOPO3_Title).MaximumLength(200);
            RuleFor(x => x.sOPO3_BusinessPhone).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.sOPO3_HomePhone).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.sOPO3_HomeAddress).MaximumLength(200);

            RuleFor(x => x.License_id).NotEmpty();
        }
    }

    public class V_BusinessLicenseRegistrationStep3 : AbstractValidator<DTO_BusinessLicenseRegistrationStep3>
    {
        public V_BusinessLicenseRegistrationStep3()
        {
            RuleFor(x => x.iType_LegalOrg).MaximumLength(200);
            RuleFor(x => x.bMember).NotNull();
            RuleFor(x => x.iOwned_SWST_Percent).InclusiveBetween(0, 100);
            RuleFor(x => x.iOwned_AmeriIndian_percent).LessThanOrEqualTo(x => 100 - x.iOwned_SWST_Percent);
            RuleFor(x => x.directions_nearest_town).MaximumLength(200);
            RuleFor(x => x.License_id).NotEmpty();
        }
    }

    public class V_BusinessLicenseRegistrationStep4 : AbstractValidator<DTO_BusinessLicenseRegistrationStep4>
    {
        private RegularExpressions reg = new();

        public V_BusinessLicenseRegistrationStep4()
        {
            RuleFor(x => x.iReason_License).MaximumLength(200);
            RuleFor(x => x.prior_owner_Name).MaximumLength(200);
            RuleFor(x => x.prior_owner_Title).MaximumLength(200);
            RuleFor(x => x.prior_owner_BusinessPhone).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.prior_owner_HomePhone).Matches(reg.phoneOrEmpty);
            RuleFor(x => x.prior_owner_HomeAddress).MaximumLength(200);
            RuleFor(x => x.sCTT_Id_Current).MaximumLength(200);
            RuleFor(x => x.License_id).NotEmpty();
        }
    }

    public class V_BusinessLicenseRegistrationStep5 : AbstractValidator<DTO_BusinessLicenseRegistrationStep5>
    {
        private RegularExpressions reg = new();

        public V_BusinessLicenseRegistrationStep5()
        {
            RuleFor(x => x.sPwd).Matches(reg.password);
            RuleFor(x => x.secretQuestion).MaximumLength(200);
            RuleFor(x => x.secretAnswer).MaximumLength(200);
            RuleFor(x => x.sEmail).MaximumLength(254).EmailAddress();
            RuleFor(x => x.License_id).NotEmpty();
            RuleFor(x => x.bMember).NotNull();
        }
    }
}