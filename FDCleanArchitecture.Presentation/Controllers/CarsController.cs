using EntityFrameworkCorePagination.Nuget.Pagination;
using FDCleanArchitecture.Application.Features.CarFeature.Commands.CreateCar;
using FDCleanArchitecture.Application.Features.CarFeature.Queries.GetAllCar;
using FDCleanArchitecture.Domain.Dtos;
using FDCleanArchitecture.Domain.Entities;
using FDCleanArchitecture.Infrastructure.Authorization;
using FDCleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FDCleanArchitecture.Presentation.Controllers
{
    public class CarsController : ApiController
    {
        public CarsController(IMediator mediator) : base(mediator)
        {
        }
        [RoleFilter("Create")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateCarCommand request,CancellationToken cancellationToken)
        {
            MessageResponse response= await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [RoleFilter("GetAll")]
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAll(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            PaginationResult<Car> response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
