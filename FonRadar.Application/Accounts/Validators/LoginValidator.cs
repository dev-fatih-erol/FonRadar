using FluentValidation;
using FonRadar.Application.Accounts.Requests;

namespace FonRadar.Application.Accounts.Validators
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
		public LoginValidator()
		{
            RuleFor(p => p.Email)
               .NotEmpty();

            RuleFor(p => p.Password)
               .NotEmpty();
        }
	}
}

