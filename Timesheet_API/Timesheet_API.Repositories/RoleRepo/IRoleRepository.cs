using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.RoleRepo
{
    public interface IRoleRepository : IRepository<Role>
    {
        public Role GetRoleByName(string roleName);
    }
}
