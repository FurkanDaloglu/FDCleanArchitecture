using FDCleanArchitecture.Domain.Dtos;
using MediatR;

namespace FDCleanArchitecture.Application.Features.RoleFeature.Commands.CreateRole;

public sealed record CreateRoleCommand(
    string Name):IRequest<MessageResponse>;
