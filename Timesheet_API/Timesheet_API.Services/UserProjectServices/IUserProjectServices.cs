using Timesheet_API.Models.Dto.UserProjectDtos;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Services.UserProjectServices
{
    public interface IUserProjectServices
    {
        IList<UserProject> FindAll();
        UserProject FindByID(UserProjectDto userProjectDto);
        UserProject Create(UserProjectDto userProjectDto);
        UserProject Delete(UserProjectDto userProjectDto);
    }
}
