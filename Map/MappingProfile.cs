using AutoMapper;
using JsGrid.Data;
using JsGrid.Services.Persons.Commands;

namespace JsGrid.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, CreatePerson>().ReverseMap();
            CreateMap<Person, UpdatePerson>().ReverseMap();
            CreateMap<Person, DeletePerson>().ReverseMap();
        }
    }
}
