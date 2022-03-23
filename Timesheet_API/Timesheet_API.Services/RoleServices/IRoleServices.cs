using Timesheet_API.Models.Dto.RoleDtos;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Services.RoleServices
{
    public interface IRoleServices : IServices<Role>
    {
        Role Create(RoleDto roleDto);
        Role Update(RoleUpdateDto roleUpdateDto);
    }
}
