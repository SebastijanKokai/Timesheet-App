using AutoMapper;
using Timesheet_API.Models.Dto.ProjectTaskDtos;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Models.Profiles
{
    public class ProjectTaskUpdateProfile : Profile
    {
        public ProjectTaskUpdateProfile()
        {
            CreateMap<ProjectTaskUpdateDto, ProjectTask>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.UserId,
                    opt => opt.MapFrom(src => src.UserId)
                 )
                .ForMember(
                    dest => dest.ProjectId,
                    opt => opt.MapFrom(src => src.ProjectId)
                 )
                .ForMember(
                    dest => dest.CategoryId,
                    opt => opt.MapFrom(src => src.CategoryId)
                )
                .ForMember(
                    dest => dest.TaskDescription,
                    opt => opt.MapFrom(src => src.Description)
                )
                .ForMember(
                    dest => dest.TaskTime,
                    opt => opt.MapFrom(src => src.Time)
                )
                .ForMember(
                    dest => dest.TaskOvertime,
                    opt => opt.MapFrom(src => src.Overtime)
                )
                .ForMember(
                    dest => dest.TaskDate,
                    opt => opt.MapFrom(src => src.Date)
                );
        }
    }
}
