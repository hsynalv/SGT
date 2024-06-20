using SGT.Application.Abstraction.Services.Authentication;

namespace SGT.Application.Abstraction.Services;

public interface IAuthService : IExternalAuthentication, IInternalAuthentication
{

}
