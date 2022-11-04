using API.Models.DTO;
using FluentValidation;

namespace API.Validators
{
    public class V_SignUp : AbstractValidator<DTO_SignUp>
    {
        public V_SignUp()
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.EmailAddress).NotEmpty().MaximumLength(254).EmailAddress();
            RuleFor(x => x.Password).NotEmpty().Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*])[0-9a-zA-Z!@#$%^&*]{8,24}$");
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(30);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(30);
        }
    }
}
