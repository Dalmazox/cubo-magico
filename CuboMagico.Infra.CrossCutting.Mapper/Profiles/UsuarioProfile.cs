using AutoMapper;
using CuboMagico.Domain.Entities;
using CuboMagico.Domain.ViewModels;

namespace CuboMagico.Infra.CrossCutting.Mapper.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioInserirViewModel, Usuario>();
        }
    }
}
