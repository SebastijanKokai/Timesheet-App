using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.CategoryRepo
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public Category GetCategoryByName(string name);
    }
}
