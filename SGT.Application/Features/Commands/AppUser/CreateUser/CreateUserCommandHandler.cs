using MediatR;
using Microsoft.AspNetCore.Identity;
using SGT.Application.Exceptions;

namespace SGT.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.UserName,
                Email = request.Email,
                NameSurname = request.NameSurname,
                Bio = "", // TODO: Bio ve Profile Picture nul olma hatasını çöz
                ProfilePicture = "",
            }, request.Password);

            if (result.Succeeded)
            {
                return new()
                {
                    Succeeded = true,
                    Message = "Kullanıcı başarıyla oluşturuldu..."
                };
            }

            throw new UserCreateFailedException();
        }
    }
}
