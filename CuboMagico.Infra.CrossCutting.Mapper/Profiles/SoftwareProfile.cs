using AutoMapper;
using CuboMagico.Domain.Entities;
using CuboMagico.Domain.ViewModels;

namespace CuboMagico.Infra.CrossCutting.Mapper.Profiles
{
    public class SoftwareProfile : Profile
    {
        public SoftwareProfile()
        {
            CreateMap<SoftwareInserirViewModel, Software>();

            CreateMap<Software, SoftwareBuscarViewModel>()
                .ForMember(
                    destino => destino.DataCadastro,
                    opcoes => opcoes.MapFrom(origem => origem.DataCadastro.ToLocalTime())
                );
        }
    }
}
