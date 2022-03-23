using AutoMapper;
using Timesheet_API.Models.Dto.ClientDtos;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Models.Profiles
{
    public class ClientUpdateProfile : Profile
    {
        public ClientUpdateProfile()
        {
            CreateMap<ClientUpdateDto, Client>()
                .ForMember(
                    dest => dest.Country,
                    opt => opt.Ignore()
                 )
                .ForMember(
                    dest => dest.CountryId,
                    opt => opt.Ignore()
                 )
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => $"{src.Id}")
                )
                .ForMember(
                    dest => dest.ClientName,
                    opt => opt.MapFrom(src => $"{src.Name}")
                )
                .ForMember(
                    dest => dest.ClientAddress,
                    opt => opt.MapFrom(src => $"{src.Address}")
                )
                .ForMember(
                    dest => dest.ClientCity,
                    opt => opt.MapFrom(src => $"{src.City}")
                )
                .ForMember(
                    dest => dest.ClientZipCode,
                    opt => opt.MapFrom(src => $"{src.ZipCode}")
                );
        }
    }
}
