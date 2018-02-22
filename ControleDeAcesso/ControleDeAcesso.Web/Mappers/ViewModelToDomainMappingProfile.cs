using AutoMapper;
using S2Games.Entities;
using S2Games.Web.Models;

namespace S2Games.Web.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
            Mapper.CreateMap<JogoViewModel, Jogo>();
            Mapper.CreateMap<EmprestimoViewModel, Emprestimo>();
        }

    }
}