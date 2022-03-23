using Microsoft.EntityFrameworkCore;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.ProjectRepo
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository()
        {

        }

        public ProjectRepository(timesheet_dbContext context) : base(context)
        {

        }

        new public Project GetByID(Guid ID)
        {
            return table.AsNoTracking().Where(p => p.Id == ID).FirstOrDefault();
        }

        public override Project Delete(Guid ID)
        {
            Project? project = table.Find(ID);
            if (project != null)
            {
                project.DeletedDate = DateTime.UtcNow;
                context.Entry(project).State = EntityState.Modified;
                return project;
            }
            throw new NullReferenceException("There is no Project with given ID.");
        }
    }
}
