using Timesheet_API.Models.Helpers;
using Timesheet_API.Models.Parameters;

namespace Timesheet_API.Repositories
{
    public interface IParametersRepository<T> where T : class
    {
        public PagedList<T> GetAll(QueryStringParameters parameters);

        public List<string> GetFirstLettersOfObjectsArray();
    }
}
