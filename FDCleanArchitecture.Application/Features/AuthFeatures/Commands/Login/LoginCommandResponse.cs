namespace FDCleanArchitecture.Application.Features.AuthFeatures.Commands.Login
{
    public sealed record LoginCommandResponse(
        string Token,
        string RefreshToken,
        DateTime? RefreshTokenExpires,
        string UserId);
    
    
}
