using Microsoft.EntityFrameworkCore;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.ProjectTaskRepo
{
    public class ProjectTaskRepository : Repository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository()
        {

        }

        public ProjectTaskRepository(timesheet_dbContext context) : base(context)
        {

        }

        new public ProjectTask GetByID(Guid ID)
        {
            return table.AsNoTracking().Where(pt => pt.Id == ID).FirstOrDefault();
        }

    }
}
