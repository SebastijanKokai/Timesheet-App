using AutoMapper;
using Timesheet_API.Models.Dto.ProjectDtos;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Models.Profiles
{
    public class ProjectUpdateProfile : Profile
    {
        public ProjectUpdateProfile()
        {
            CreateMap<ProjectUpdateDto, Project>()
                .ForMember(
                    dest => dest.Client,
                    opt => opt.Ignore()
                 )
                .ForMember(
                    dest => dest.ClientId,
                    opt => opt.Ignore()
                 );
        }
    }
}
