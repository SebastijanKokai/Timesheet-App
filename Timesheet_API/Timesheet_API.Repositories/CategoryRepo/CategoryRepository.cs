using Microsoft.EntityFrameworkCore;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.CategoryRepo
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository()
        {

        }

        public CategoryRepository(timesheet_dbContext context) : base(context) { }

        public override Category Delete(Guid ID)
        {
            Category? category = table.Find(ID);
            if (category != null)
            {
                category.DeletedDate = DateTime.UtcNow;
                context.Entry(category).State = EntityState.Modified;
                return category;
            }
            throw new NullReferenceException("There is no Category with given ID.");
        }

        public Category GetCategoryByName(string name)
        {
            return table
                .Where(x => x.CategoryName == name)
                .FirstOrDefault();
        }
    }
}
