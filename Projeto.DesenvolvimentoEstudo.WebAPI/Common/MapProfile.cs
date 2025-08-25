using AutoMapper;
using Projeto.DesenvolvimentoEstudo.Application.Users.Commands;
using Projeto.DesenvolvimentoEstudo.WebAPI.Model.Users;

namespace Projeto.DesenvolvimentoEstudo.WebAPI.Common;

/// <summary>
///     Profile for mapping between Application and API 
/// </summary>
public class MapProfile : Profile
{
    /// <summary>
    ///     Initializes the mappings for feature
    /// </summary>
    public MapProfile()
    {
        CreateMap<GetAllCommand, GetAllUserRequest>().ReverseMap();
        CreateMap<CreateUserRequest, CreateUserCommand>().ReverseMap();
        //CreateMap<CreateUserResult, CreateUserResponse>();
    }
}
