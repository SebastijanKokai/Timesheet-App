using Timesheet_API.Models.Dto.UserDtos;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Services.UserServices
{
    public interface IUserServices : IServices<User>
    {
        User Create(UserPostDto userPostDto);
        User Update(UserUpdateDto userUpdateDto);
    }
}
