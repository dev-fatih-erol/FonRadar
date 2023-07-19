using Microsoft.AspNetCore.Identity;

namespace FonRadar.Infrastructure.Domain.Entities
{
    ///<summary>
    /// Represents a claim associated with a role.
    ///</summary>
    ///<remarks>
    /// This class extends the base class `IdentityRoleClaim<int>` to represent
    /// a claim associated with a role in ASP.NET Identity.
    ///</remarks>
    public class RoleClaim : IdentityRoleClaim<int>
    {
    }
}