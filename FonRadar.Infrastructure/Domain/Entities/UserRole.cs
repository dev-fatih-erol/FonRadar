using Microsoft.AspNetCore.Identity;

namespace FonRadar.Infrastructure.Domain.Entities
{
    ///<summary>
    /// Represents a user role mapping.
    ///</summary>
    ///<remarks>
    /// This class extends the base class `IdentityUserRole<int>` to represent
    /// a mapping between a user and a role in ASP.NET Identity.
    ///</remarks>
    public class UserRole : IdentityUserRole<int>
    {
    }
}