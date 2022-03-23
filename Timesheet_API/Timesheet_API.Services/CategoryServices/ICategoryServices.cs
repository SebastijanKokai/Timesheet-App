using Timesheet_API.Models.Dto.CategoryDtos;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Services.CategoryServices
{
    public interface ICategoryServices : IServices<Category>
    {
        public Category Create(CategoryPostDto categoryPostDto);
        public Category Update(CategoryUpdateDto categoryUpdateDto);
    }
}
