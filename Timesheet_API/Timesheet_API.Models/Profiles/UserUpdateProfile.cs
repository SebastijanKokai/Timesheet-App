﻿using AutoMapper;
using Timesheet_API.Models.Dto.UserDtos;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Models.Profiles
{
    public class UserUpdateProfile : Profile
    {
        public UserUpdateProfile()
        {
            CreateMap<UserUpdateDto, User>()
                .ForMember(
                    dest => dest.Role,
                    opt => opt.Ignore()
                )
                .ForMember(
                    dest => dest.RoleId,
                    opt => opt.Ignore()
                )
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                 )
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom((src, dest) =>
                    {
                        return src.Name.Split(' ')[0];
                    })
                 )
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom((src, dest) =>
                    {
                        return src.Name.Split(' ')[1];
                    })
                 )
                .ForMember(
                    dest => dest.Username,
                    opt => opt.MapFrom(src => src.Username)
                )
                .ForMember(
                    dest => dest.UserPassword,
                    opt => opt.MapFrom(src => src.Password)
                )
                .ForMember(
                    dest => dest.HoursPerWeek,
                    opt => opt.MapFrom(src => src.HoursPerWeek)
                )
                .ForMember(
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email)
                )
                .ForMember(
                    dest => dest.UserStatus,
                    opt => opt.MapFrom(src => src.UserStatus)
                );
        }
    }
}
