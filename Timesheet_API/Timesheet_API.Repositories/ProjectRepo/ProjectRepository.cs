using Microsoft.EntityFrameworkCore;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Helpers;
using Timesheet_API.Models.Models;
using Timesheet_API.Models.Parameters;

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

        public PagedList<Project> GetAll(ProjectParameters projectParameters)
        {
            IQueryable<Project> projects = table;

            if (projectParameters.FirstLetter != null)
            {
                projects = table.Where(pr => pr.ProjectName.FirstOrDefault() == projectParameters.FirstLetter);
            }

            SearchByName(ref projects, projectParameters.Name);

            return PagedList<Project>
                .ToPagedList(projects.OrderBy(pr => pr.ProjectName),
                projectParameters.PageNumber,
                projectParameters.PageSize);
        }

        private void SearchByName(ref IQueryable<Project> projects, string projectName)
        {
            if (!projects.Any() || string.IsNullOrWhiteSpace(projectName))
                return;

            projects = projects.Where(pr => pr.ProjectName.ToLower().Contains(projectName.Trim().ToLower()));
        }

        public List<string> GetFirstLettersOfProjectsArray()
        {
            var projects = (from pr in table
                           let first = pr.ProjectName.Substring(0, 1)
                           orderby first
                           select first).Distinct();

            List<string> firstLetters = new List<string>();

            foreach (var item in projects)
            {
                firstLetters.Add(item);
            }

            return firstLetters;
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
