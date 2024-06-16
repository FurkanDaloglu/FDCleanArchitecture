using FDCleanArchitecture.Domain.Entities;
using FDCleanArchitecture.Domain.Repositories;
using FDCleanArchitecture.Persistance.Context;
using GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCleanArchitecture.Presentation.Repositories
{
    public sealed class CarRepository:Repository<Car, AppDbContext>,ICarRepository
    {
        public CarRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
