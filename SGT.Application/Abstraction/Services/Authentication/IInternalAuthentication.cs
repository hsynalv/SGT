namespace SGT.Application.Abstraction.Services.Authentication;

public interface IInternalAuthentication
{
    Task<DTOs.Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
    Task<DTOs.Token> RefreshTokenLoginAsync(string refreshToken);
}