using AutoMapper;
using FilmesApi1.Data.Dtos;
using FilmesApi1.Models;

namespace FilmesApi1.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
        }

    }
}
