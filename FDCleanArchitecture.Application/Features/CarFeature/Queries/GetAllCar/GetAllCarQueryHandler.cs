using EntityFrameworkCorePagination.Nuget.Pagination;
using FDCleanArchitecture.Application.Services;
using FDCleanArchitecture.Domain.Entities;
using MediatR;

namespace FDCleanArchitecture.Application.Features.CarFeature.Queries.GetAllCar
{
    public sealed class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, PaginationResult<Car>>
{
        private readonly ICarService _carService;

        public GetAllCarQueryHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<PaginationResult<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            PaginationResult<Car> cars = await _carService.GetAllAsync(request, cancellationToken);
            return cars;
        }
    }
}
