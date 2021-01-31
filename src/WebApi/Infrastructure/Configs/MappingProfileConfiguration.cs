using AutoMapper;
using WebApi.Data.Entity;
using WebApi.DTO.Request;
using WebApi.DTO.Response;

namespace WebApi.Infrastructure.Configs
{
    public class MappingProfileConfiguration : Profile
    {
        public MappingProfileConfiguration()
        {
            CreateMap<Person, CreatePersonRequest>().ReverseMap();
            CreateMap<Person, UpdatePersonRequest>().ReverseMap();
            CreateMap<Person, PersonQueryResponse>().ReverseMap();
        }
    }
}
