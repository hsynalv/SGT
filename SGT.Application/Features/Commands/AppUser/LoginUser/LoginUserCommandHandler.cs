using MediatR;
using Microsoft.AspNetCore.Identity;
using SGT.Application.Exceptions;

namespace SGT.Application.Features.Commands.AppUser.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
    private readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;

    public LoginUserCommandHandler(SignInManager<Domain.Entities.Identity.AppUser> signInManager, UserManager<Domain.Entities.Identity.AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }


    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
       Domain.Entities.Identity.AppUser user =  await _userManager.FindByNameAsync(request.UserNameOrEmail);
       if (user == null)
           user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);

       if (user == null)
           throw new UserNotFoundException();

       SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);


       return new();

    }
}