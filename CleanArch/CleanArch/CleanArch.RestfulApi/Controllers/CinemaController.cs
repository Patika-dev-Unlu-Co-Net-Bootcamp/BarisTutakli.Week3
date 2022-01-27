using CleanArch.Application.Cinemas.Commands.Request;
using CleanArch.Application.Cinemas.Commands.Response;
using CleanArch.Application.Cinemas.Handlers;
using CleanArch.Application.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.RestfulApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly CreateCinemaCommandHandler _createCinemaCommandHandler;
        public CinemaController(CreateCinemaCommandHandler createCinemaCommandHandler)
        {
            _createCinemaCommandHandler = createCinemaCommandHandler;
        }
        [HttpPost]
        public async Task<ActionResult<CreateCinemaCommandResponse>> Create(CreateCinemaCommandRequest createCinemaCommandRequest)
        {
            CreateCinemaCommandValidator validator = new CreateCinemaCommandValidator();
            validator.ValidateAndThrow(createCinemaCommandRequest);
            var result = await _createCinemaCommandHandler.handle(createCinemaCommandRequest);
            return Ok(result);
        }

    }
}
