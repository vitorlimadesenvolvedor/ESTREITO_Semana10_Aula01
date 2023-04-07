using Aula01.Controllers;
using Aula01.Models;
using AutoMapper;

namespace Aula01.Profiles;

public class MovieProfile : Profile
{

    public MovieProfile()
    {
        CreateMap<FilmeCriacaoDto, Movie>()
                   .ForMember(
                       dest => dest.Titulo,
                       opt => opt.MapFrom(src => src.Titulo)
                   )
                   .ForMember(
                       dest => dest.Genero,
                       opt => opt.MapFrom(src => src.Genero)
                   )
                   .ForMember(
                       dest => dest.DataDeLancamento,
                       opt => opt.MapFrom(src => src.DataDeLancamento)
                   );
        
        CreateMap<Movie, FilmeCriacaoSaidaDto>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id)
            )
            .ForMember(
                dest => dest.Titulo,
                opt => opt.MapFrom(src => src.Titulo)
            )
            .ForMember(
                dest => dest.Genero,
                opt => opt.MapFrom(src => src.Genero)
            )
            .ForMember(
                dest => dest.DataDeLancamento,
                opt => opt.MapFrom(src => src.DataDeLancamento)
            );
    }

}