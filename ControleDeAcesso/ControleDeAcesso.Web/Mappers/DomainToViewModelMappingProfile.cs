using AutoMapper;
using S2Games.Entities;
using S2Games.Web.Models;

namespace S2Games.Web.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
            Mapper.CreateMap<Jogo, JogoViewModel>();
            Mapper.CreateMap<Emprestimo, EmprestimoViewModel>();
        }
    }
}