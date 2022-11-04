using API.Models.Domain;
using API.Models.DTO;
using AutoMapper;

namespace API.Profiles
{
    public class P_Profiles : Profile
    {
        public P_Profiles()
        {
            CreateMap<D_State, DTO_State>().ReverseMap();
            CreateMap<D_City, DTO_City>().ReverseMap();
            CreateMap<D_City, DTO_ZIP>().ReverseMap();
            CreateMap<D_BusinessLicense, DTO_BusinessLicense>().ReverseMap();
            CreateMap<D_BusinessLicense, DTO_BusinessLicenseRegistrationStep1>().ReverseMap();
            CreateMap<D_BusinessLicense, DTO_BusinessLicenseRegistrationStep2>().ReverseMap();
            CreateMap<D_BusinessLicense, DTO_BusinessLicenseRegistrationStep3>().ReverseMap();
            CreateMap<D_BusinessLicense, DTO_BusinessLicenseRegistrationStep4>().ReverseMap();
            CreateMap<D_BusinessLicense, DTO_BusinessLicenseRegistrationStep5>().ReverseMap();
            CreateMap<D_SICHeader, DTO_SICHeader>().ReverseMap();
            CreateMap<D_SIC, DTO_SIC>().ReverseMap();
            CreateMap<D_Role, DTO_Role>().ReverseMap();
        }
    }
}