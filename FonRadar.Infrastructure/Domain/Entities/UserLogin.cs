using Microsoft.AspNetCore.Identity;

namespace FonRadar.Infrastructure.Domain.Entities
{
    ///<summary>
    /// Represents a login associated with a user.
    ///</summary>
    ///<remarks>
    /// This class extends the base class `IdentityUserLogin<int>` to represent
    /// a login associated with a user in ASP.NET Identity.
    ///</remarks>
    public class UserLogin : IdentityUserLogin<int>
    {
    }
}