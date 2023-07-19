using Microsoft.AspNetCore.Identity;

namespace FonRadar.Infrastructure.Domain.Entities
{
    ///<summary>
    /// Represents a claim associated with a user.
    ///</summary>
    ///<remarks>
    /// This class extends the base class `IdentityUserClaim<int>` to represent
    /// a claim associated with a user in ASP.NET Identity.
    ///</remarks>
    public class UserClaim : IdentityUserClaim<int>
    {
    }
}