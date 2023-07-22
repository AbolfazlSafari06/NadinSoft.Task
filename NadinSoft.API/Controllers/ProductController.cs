using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NadinSoft.API.MediatR.Commands;
using NadinSoft.API.MediatR.Queries;
using NadinSoft.Application.Contract;
using NadinSoft.Application.Contract.DTO.Product;
using NadinSoft.Application.Contract.Exceptions;
using NadinSoft.Application.Contract.Extension;
using NadinSoft.Application.Contract.Identity;
using NadinSoft.Application.Contract.Routes;


namespace NadinSoft.API.Controllers;

[ApiController]
[Route(Routes.Product.RootAddress)]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator; 
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseObject<List<ProductDto>>))]
    public async Task<IActionResult> GetAsync(string? userId)
    {
        try
        {
            var products = await _mediator.Send(new GetProductsQuery{UserId = userId });
            var result = new ResponseObject<List<ProductDto>>()
            {
                Data = products,
                IsSucceed = true,
            };
            return Ok(result);
        }
        catch (NadinSoftException e)
        {
            return BadRequest(new ResponseObject<object>()
            {
                StatusCode = e.StatusCode,
                IsSucceed = false,
                Message = e.Message
            });
        }
    }

    [Authorize(Roles = StaticUserRoles.USER)]
    [HttpGet(Routes.Product.Get.GetById)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseObject<ProductDto>))]
    public async Task<IActionResult> GetAsync([Required(ErrorMessage = "شناسه الزامی میباشد")] Guid id)
    {
        try
        {
            var userId = User.GetLoggedInUserId<string>();
            var product = await _mediator.Send(new GetProductByIdQuery { Id = id,UserId = userId });
            var result = new ResponseObject<ProductDto>()
            {
                Data = product,
                IsSucceed = true,
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

    [HttpPost]
    [Authorize(Roles = StaticUserRoles.USER)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseObject<ProductDto>))]
    public async Task<IActionResult> PostAsync([FromBody, Required(ErrorMessage = nameof(CreateProductDto))] CreateProductDto command)
    {
        try
        {
            var userId = User.GetLoggedInUserId<string>();
            var product = await _mediator.Send(new CreateProductCommand { UserId = userId,CreateProductDto = command });
            var result = new ResponseObject<ProductDto>()
            {
                StatusCode = 201,
                Data = product,
                IsSucceed = true,
            };
            return Ok(result);
        }
        catch (NadinSoftException e)
        {
            return StatusCode(e.StatusCode, new ResponseObject { StatusCode = e.StatusCode, IsSucceed = false, Message = e.Message });
        }
    }

    [HttpPut]
    [Authorize(Roles = StaticUserRoles.USER)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseObject<ProductDto>))]
    public async Task<IActionResult> Put([FromBody, Required(ErrorMessage = nameof(UpdateProductDto))] UpdateProductDto command)
    {
        try
        {
            var userId = User.GetLoggedInUserId<string>();
            var product = await _mediator.Send(new UpdateProductCommand {UserId = userId, UpdateProductDto = command });
            var result = new ResponseObject<ProductDto>()
            {
                Data = product,
                IsSucceed = true,
            };
            return Ok(result);
        }
        catch (NadinSoftException e)
        {
            return StatusCode(e.StatusCode, new ResponseObject { StatusCode = e.StatusCode, IsSucceed = false, Message = e.Message });
        }
    }

    [HttpDelete(Routes.Product.Delete)]
    [Authorize(Roles = StaticUserRoles.USER)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseObject))]
    public async Task<IActionResult> Delete([Required(ErrorMessage = "شناسه الزامی میباشد")] Guid id)
    {
        try
        {
            var userId = User.GetLoggedInUserId<string>();
            await _mediator.Send(new DeleteProductCommand {UserId = userId,id = id });
            var result = new ResponseObject()
            {
                IsSucceed = true,
            };
            return Ok(result);
        }
        catch (NadinSoftException e)
        {
            return StatusCode(e.StatusCode, new ResponseObject { StatusCode = e.StatusCode, IsSucceed = false, Message = e.Message });
        }
    }
}