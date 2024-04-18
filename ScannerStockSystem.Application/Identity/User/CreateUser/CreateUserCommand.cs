using MediatR;
using ScannerStockSystem.Application.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerStockSystem.Application.Identity.User.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmationPassword { get; set; }
        public List<string> Roles { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IIdentityService _identityService;
        public CreateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.CreateUserAsync(request.UserName,request.FirstName,request.LastName, request.Password, request.Email, request.Roles);
            return result.isSucceed ? 1 : 0;
        }
    }
}
