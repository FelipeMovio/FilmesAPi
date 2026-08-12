using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile() {

            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>()
                .ForMember(cinemaDto => cinemaDto.Endereco,
                opcao => opcao.MapFrom(cinema => cinema.Endereco))
                           .ForMember(cinemaDto => cinemaDto.Sessoes,
                opcao => opcao.MapFrom(cinema => cinema.Sessoes));
        }
    }
}
