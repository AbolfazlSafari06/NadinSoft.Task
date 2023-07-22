using MediatR;
using Microsoft.AspNetCore.Mvc;
using NadinSoft.API.MediatR.Commands;
using NadinSoft.Application.Contract;
using NadinSoft.Application.Contract.DTO.Auth;
using NadinSoft.Application.Contract.Exceptions;
using NadinSoft.Application.Contract.Routes;
using System.ComponentModel.DataAnnotations;

namespace NadinSoft.API.Controllers;

[Route(Routes.Auth.RootAddress)]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route(Routes.Auth.Login)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseObject<string>))]
    public async Task<IActionResult> Login([FromBody, Required(ErrorMessage = nameof(LoginDto))] LoginDto loginDto)
    {
        try
        {
            var loginResult = await _mediator.Send(new LoginCommand() { LoginDto = loginDto });

            var result = new ResponseObject<string>()
            {
                Data = loginResult,
                IsSucceed = true,
            };

            return Ok(result);
        }
        catch (Exception e)
        {
            var result = new ResponseObject()
            {
                IsSucceed = false,
                Message = e.Message,
            };
            return Unauthorized(result);
        }
    }

    [HttpPost]
    [Route(Routes.Auth.Register)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseObject))]
    public async Task<IActionResult> Register([FromBody, Required(ErrorMessage = nameof(RegisterDto))] RegisterDto registerDto)
    {
        try
        {
            await _mediator.Send(new RegisterCommand() { RegisterDto = registerDto });

            var result = new ResponseObject()
            {
                IsSucceed = false,
                StatusCode = 400,
            };
            return Ok(result);
        }
        catch (NadinSoftException e)
        {
            return BadRequest(new ResponseObject()
            {
                StatusCode = e.StatusCode,
                IsSucceed = false,
                Message = e.Message
            });
        }
    }
}