using EntityFrameworkCorePagination.Nuget.Pagination;
using FDCleanArchitecture.Application.Features.CarFeature.Commands.CreateCar;
using FDCleanArchitecture.Application.Features.CarFeature.Queries.GetAllCar;
using FDCleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCleanArchitecture.Application.Services
{
    public interface ICarService
    {
        Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken);
        Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken);
    }
}
