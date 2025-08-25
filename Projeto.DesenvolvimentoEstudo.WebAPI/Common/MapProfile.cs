using AutoMapper;
using Projeto.DesenvolvimentoEstudo.Application.Users.Requests;
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
        CreateMap<GetAllRequest, GetAllUserRequest>().ReverseMap();
        //CreateMap<CreateUserResult, CreateUserResponse>();
        //CreateMap<CreateUserResult, CreateUserResponse>();
    }
}
