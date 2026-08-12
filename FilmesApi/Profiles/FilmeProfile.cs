using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class FilmeProfile : Profile
{

    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme,UpdateFilmeDto>();

        CreateMap<UpdateFilmeParcialDto, Filme>()
    .ForAllMembers(opts =>
        opts.Condition((src, dest, srcMember) => srcMember != null));
        //"Só mapeie a propriedade se o valor recebido não for null."

        CreateMap<Filme, ReadFilmeDto>()
            .ForMember(filmeDto => filmeDto.Sessoes,
            opt => opt.MapFrom(filme=> filme.Sessoes));
    }
}
