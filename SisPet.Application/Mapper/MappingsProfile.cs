using AutoMapper;
using SisPet.Application.Dto;
using SisPet.Domain.Entidades;

namespace SisPet.Application.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<PessoaDTO, Pessoa>().ReverseMap();
        }
    }

   
}
