using MediatR;
using Microsoft.AspNetCore.Identity;
using SGT.Application.Abstraction.Services.Authentication;
using SGT.Application.Abstraction.Token;
using SGT.Application.DTOs;
using SGT.Application.Exceptions;

namespace SGT.Application.Features.Commands.AppUser.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private readonly IInternalAuthentication _authService;

    public LoginUserCommandHandler(IInternalAuthentication authService)
    {
        _authService = authService;
    }


    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var token = await _authService.LoginAsync(request.UserNameOrEmail, request.Password, 15);
        return new LoginUserSuccessCommandResponse()
        {
            Token = token
        };
    }
}