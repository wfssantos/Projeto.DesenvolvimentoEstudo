using AutoMapper;
using MediatR;
using Projeto.DesenvolvimentoEstudo.Application.Companies.Commands;
using Projeto.DesenvolvimentoEstudo.Application.Companies.Response;
using Projeto.DesenvolvimentoEstudo.Common.Security;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DesenvolvimentoEstudo.Application.Companies.Handlers;

/// <summary>
///     Handler for processing CreateCompanyCommand requests
/// </summary>
public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyCommandResponse>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    /// <summary>
    ///     Initializes a new instance of CreateCompanyHandler
    /// </summary>
    /// <param name="companyRepository">The company repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="passwordHasher">The password hasher service</param>
    public CreateCompanyHandler(ICompanyRepository companyRepository, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    /// <summary>
    ///     Handles the CreateCompanyCommand request
    /// </summary>
    /// <param name="command">The CreateCompany command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created company details</returns>
    public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
    {
        var company = _mapper.Map<Company>(command);
        var createdCompany = await _companyRepository.CreateAsync(company, cancellationToken);
        var result = _mapper.Map<CreateCompanyCommandResponse>(createdCompany);
        return result;
    }
}
