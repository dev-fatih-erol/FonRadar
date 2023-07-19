using System.Security.Claims;

namespace FonRadar.Application.Common.Accessors
{
    public interface IUserAccessor
	{
        int UserId { get; }

        ClaimsPrincipal User { get; }
    }
}