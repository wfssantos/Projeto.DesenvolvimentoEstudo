using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.DesenvolvimentoEstudo.Application.CompaniesProducts.Commands;
using Projeto.DesenvolvimentoEstudo.WebAPI.Common;
using Projeto.DesenvolvimentoEstudo.WebAPI.Model.CompaniesProducts;

namespace Projeto.DesenvolvimentoEstudo.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesProductsController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CompaniesProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCompaniesProductsRequest filter, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<GetAllCompanyProductCommand>(filter);
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
}
