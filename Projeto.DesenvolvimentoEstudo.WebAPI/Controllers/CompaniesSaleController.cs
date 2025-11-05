using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.DesenvolvimentoEstudo.Application.CompaniesSales.Commands;
using Projeto.DesenvolvimentoEstudo.WebAPI.Common;
using Projeto.DesenvolvimentoEstudo.WebAPI.Model.CompaniesSales;

namespace Projeto.DesenvolvimentoEstudo.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesSaleController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CompaniesSaleController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCompaniesSalesRequest filter, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<GetAllCompanySaleCommand>(filter);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
