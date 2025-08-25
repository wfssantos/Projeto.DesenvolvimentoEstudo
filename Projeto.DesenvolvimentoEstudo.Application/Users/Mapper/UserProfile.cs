using AutoMapper;
using Projeto.DesenvolvimentoEstudo.Application.Users.Commands;
using Projeto.DesenvolvimentoEstudo.Application.Users.Results;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;

namespace Projeto.DesenvolvimentoEstudo.Application.Users.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, CreateUserResult>().ReverseMap();        
    }
}
