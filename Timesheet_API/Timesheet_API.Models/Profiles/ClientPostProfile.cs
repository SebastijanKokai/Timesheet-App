using AutoMapper;
using Timesheet_API.Models.Dto.ClientDtos;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Models.Profiles
{
    public class ClientPostProfile : Profile
    {
        public ClientPostProfile()
        {
            // MapFrom throws exception when null
            // ResolveUsing doesn't, but raises performance
            CreateMap<ClientPostDto, Client>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.Ignore()
                 )
                .ForMember(
                    dest => dest.Country,
                    opt => opt.Ignore()
                 )
                .ForMember(
                    dest => dest.CountryId,
                    opt => opt.Ignore()
                 )
                .ForMember(
                    dest => dest.ClientName,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.ClientAddress,
                    opt => opt.MapFrom(src => src.Address)
                )
                .ForMember(
                    dest => dest.ClientCity,
                    opt => opt.MapFrom(src => src.City)
                )
                .ForMember(
                    dest => dest.ClientZipCode,
                    opt => opt.MapFrom(src => src.ZipCode)
                );
        }
    }
}
