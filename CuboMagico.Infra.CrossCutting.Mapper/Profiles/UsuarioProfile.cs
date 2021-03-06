﻿using AutoMapper;
using CuboMagico.Domain.Entities;
using CuboMagico.Domain.ViewModels;

namespace CuboMagico.Infra.CrossCutting.Mapper.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioInserirViewModel, Usuario>();

            CreateMap<Usuario, UsuarioBuscarViewModel>()
                .ForMember(
                    destino => destino.DataCadastro,
                    opcoes => opcoes.MapFrom(origem => origem.DataCadastro.ToLocalTime())
                )
                .ForMember(
                    destino => destino.Softwares,
                    opcoes => opcoes.MapFrom(origem => origem.Softwares)
                );
        }
    }
}
