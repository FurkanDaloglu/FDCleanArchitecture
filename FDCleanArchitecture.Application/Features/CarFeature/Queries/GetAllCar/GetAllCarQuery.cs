using EntityFrameworkCorePagination.Nuget.Pagination;
using FDCleanArchitecture.Domain.Entities;
using MediatR;

namespace FDCleanArchitecture.Application.Features.CarFeature.Queries.GetAllCar
{
    public sealed record GetAllCarQuery(
        int PageNumber=1,
        int PageSize=10,
        string Search=""):IRequest<PaginationResult<Car>>;
}
