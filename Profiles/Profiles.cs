using API.Models.Domain;
using API.Models.DTO;
using AutoMapper;

namespace API.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<D_SIC, DTO_SIC>().ReverseMap();
            CreateMap<D_State, DTO_State>().ReverseMap();
        }
    }
}