using FonRadar.Application.Accounts.Responses;
using MediatR;

namespace FonRadar.Application.Accounts.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {
		public string Email { get; }
		public string Password { get; }

		public LoginCommand(
			string email, string password)
		{
			Email = email;
			Password = password;
		}
	}
}