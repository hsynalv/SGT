using MediatR;
using Microsoft.AspNetCore.Identity;
using SGT.Application.Abstraction.Services;
using SGT.Application.DTOs.User;
using SGT.Application.Exceptions;

namespace SGT.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {

            CreateUserResponseDto response =  await _userService.CreateAsync(new()
            {
                Email = request.Email,
                NameSurname = request.NameSurname,
                Password = request.Password,
                PasswrodConfirm = request.PasswrodConfirm,
                UserName = request.UserName
            });
            

            // TODO: Hatalı giriş olsa bile 200 kodu dönüyor.
            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded
            };
        }
    }
}
