using Microsoft.AspNetCore.Identity;

namespace FonRadar.Infrastructure.Domain.Entities
{
    ///<summary>
    /// Represents a role.
    ///</summary>
    ///<remarks>
    /// This class extends the base class `IdentityRole<int>` to utilize
    /// the role-based authorization features provided by ASP.NET Identity.
    ///</remarks>
    public class Role : IdentityRole<int>
    {
    }
}