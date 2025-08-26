using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.DesenvolvimentoEstudo.Application.Companies.Commands;
using Projeto.DesenvolvimentoEstudo.WebAPI.Common;
using Projeto.DesenvolvimentoEstudo.WebAPI.Model.Companies;

namespace Projeto.DesenvolvimentoEstudo.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CompaniesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCompaniesRequest filter, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<GetAllCompanyCommand>(filter);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
