using API.Models.Domain;
using API.Models.DTO;
using AutoMapper;

namespace API.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<D_Role, DTO_Role>().ReverseMap();
            CreateMap<D_GroupOfSICCodes, DTO_GroupOfSICCodes>().ReverseMap();
            CreateMap<D_SICCode, DTO_SICCode>().ReverseMap();
            CreateMap<D_StateUS, DTO_StateUS>().ReverseMap();
            CreateMap<D_City, DTO_City>().ReverseMap();
            CreateMap<D_ZipCode, DTO_ZipCode>().ReverseMap();
        }
    }
}