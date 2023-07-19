using Microsoft.AspNetCore.Identity;

namespace FonRadar.Infrastructure.Domain.Entities
{
    ///<summary>
    /// Represents a token associated with a user.
    ///</summary>
    ///<remarks>
    /// This class extends the base class `IdentityUserToken<int>` to represent
    /// a token associated with a user in ASP.NET Identity.
    ///</remarks>
    public class UserToken : IdentityUserToken<int>
    {
    }

}