using Timesheet_API.Models.Helpers;
using Timesheet_API.Models.Models;
using Timesheet_API.Models.Parameters;

namespace Timesheet_API.Repositories.ProjectRepo
{
    public interface IProjectRepository : IRepository<Project>
    {
        public PagedList<Project> GetAll(ProjectParameters projectParameters);
        public List<string> GetFirstLettersOfProjectsArray();

    }
}
