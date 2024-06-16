using FDCleanArchitecture.Domain.Dtos;
using MediatR;

namespace FDCleanArchitecture.Application.Features.CarFeature.Commands.CreateCar;

public sealed record CreateCarCommand(
    string Name,
    string Model,
    int EnginePower):IRequest<MessageResponse>;
