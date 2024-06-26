﻿using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using FDCleanArchitecture.Application.Features.CarFeature.Commands.CreateCar;
using FDCleanArchitecture.Application.Features.CarFeature.Queries.GetAllCar;
using FDCleanArchitecture.Application.Services;
using FDCleanArchitecture.Domain.Entities;
using FDCleanArchitecture.Domain.Repositories;
using FDCleanArchitecture.Persistance.Context;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCleanArchitecture.Persistance.Services
{
    public sealed class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _carRepository = carRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken)
        {

            Car car=_mapper.Map<Car>(request);

            //await _context.Set<Car>().AddAsync(car,cancellationToken);
            //await _context.SaveChangesAsync(cancellationToken);

            await _carRepository.AddAsync(car, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            PaginationResult<Car> cars = await _carRepository.GetWhere(p=>p.Name.ToLower().Contains(request.Search.ToLower())).OrderBy(p=>p.Name).ToPagedListAsync(request.PageNumber,request.PageSize,cancellationToken);
            return cars;
        }
    }
}
