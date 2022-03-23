using Microsoft.EntityFrameworkCore;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.RoleRepo
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository()
        {

        }

        public RoleRepository(timesheet_dbContext context) : base(context)
        {

        }

        public override Role Delete(Guid ID)
        {
            Role? role = context.Roles.Include(r => r.UserTables).FirstOrDefault(i => i.Id == ID);

            if (role != null)
            {
                role.DeletedDate = DateTime.UtcNow;
                context.Entry(role).State = EntityState.Modified;
                return role;
            }
            throw new NullReferenceException("There is no Role with given ID.");
            //Role? role = context.Roles.Include(r => r.UserTables).FirstOrDefaultAsync(i => i.PropertyGroupName == name);

        }

        public Role GetRoleByName(string roleName)
        {
            Role role = table.Where(x => x.RoleName == roleName).FirstOrDefault();
            return role;
        }
    }
}
