using FDCleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;
using FDCleanArchitecture.Domain.Dtos;
using FDCleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FDCleanArchitecture.Presentation.Controllers
{
    public class UserRoleController : ApiController
    {
        public UserRoleController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            MessageResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
