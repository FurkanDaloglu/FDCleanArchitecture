﻿using FDCleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using FDCleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using FDCleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using FDCleanArchitecture.Domain.Dtos;
using FDCleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDCleanArchitecture.Presentation.Controllers
{
    
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
        {
            MessageResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
        {
            LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTokenByRefreshToken(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
