using AutoMapper;
using FDCleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using FDCleanArchitecture.Application.Features.CarFeature.Commands.CreateCar;
using FDCleanArchitecture.Domain.Entities;

namespace FDCleanArchitecture.Persistance.Mappings
{
    public sealed class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCarCommand, Car>().ReverseMap();
            CreateMap<RegisterCommand,AppUser>();
        }
    }
}
