using Microsoft.AspNetCore.Identity;

namespace FDCleanArchitecture.Domain.Entities;

public sealed class AppUser:IdentityUser<string>
{
    public AppUser()
    {
        Id=Guid.NewGuid().ToString();
    }
    public string NameLastName { get; set; }
    public string RefrechToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }
}
