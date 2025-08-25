using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.DesenvolvimentoEstudo.Application.Users.Commands;
using Projeto.DesenvolvimentoEstudo.Application.Users.Queries;
using Projeto.DesenvolvimentoEstudo.WebAPI.Common;
using Projeto.DesenvolvimentoEstudo.WebAPI.Model.Users;
using System.Threading;

namespace Projeto.DesenvolvimentoEstudo.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    ///     Get all users
    /// </summary>
    /// <param name="filter">Filters</param>
    /// <returns>List all users with filter</returns>
    [HttpGet("GetAll")]
    //[ProducesResponseType(typeof(ApiResponseWithData<GetUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllUserRequest filter, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<GetAllCommand>(filter);
        var result = await _mediator.Send(new ListUserQuery(command), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    ///     Create a new user
    /// </summary>
    /// <param name="request">The user creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    [HttpPost("Create")]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateUserResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateUserCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created();
    }

    /// <summary>
    ///     Alter user
    /// </summary>
    /// <param name="request">The user creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateUserResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Alter([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        return Ok(null);
    }

    /// <summary>
    ///     Delete user
    /// </summary>
    /// <param name="request">The user creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateUserResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        return Ok(null);
    }
}
