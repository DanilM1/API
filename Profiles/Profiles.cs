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
            CreateMap<D_BusinessLicense, DTO_BusinessLicense>().ReverseMap();
            CreateMap<D_BusinessLicense, DTO_BusinessLicenseRegistrationStep1>().ReverseMap();
            CreateMap<D_BusinessLicense, DTO_BusinessLicenseRegistrationStep2>().ReverseMap();
            CreateMap<D_BusinessLicense, DTO_BusinessLicenseRegistrationStep3>().ReverseMap();
            CreateMap<D_BusinessLicense, DTO_BusinessLicenseRegistrationStep4>().ReverseMap();
            CreateMap<D_BusinessLicense, DTO_BusinessLicenseRegistrationStep5>().ReverseMap();
        }
    }
}