using AutoMapper;
using Timesheet_API.Models.CustomExceptions;
using Timesheet_API.Models.Dto.CategoryDtos;
using Timesheet_API.Models.Models;
using Timesheet_API.Repositories.CategoryRepo;

namespace Timesheet_API.Services.CategoryServices
{
    public class CategoryServices : ICategoryServices
    {
        ICategoryRepository categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
        }

        public IList<Category> FindAll()
        {
            return categoryRepository.GetAll();
        }

        public Category FindByID(Guid ID)
        {
            return categoryRepository.GetByID(ID);
        }

        public Category Create(CategoryPostDto categoryPostDto)
        {
            if (categoryRepository.GetCategoryByName(categoryPostDto.CategoryName) != null)
            {
                throw new ObjectAlreadyExistsInDatabaseException("Category name already exists.");
            }
            Category category = new Category();
            category.Id = Guid.NewGuid();

            category.CategoryName = categoryPostDto.CategoryName;

            categoryRepository.Insert(category);
            categoryRepository.Save();

            return category;
        }

        public Category Update(CategoryUpdateDto categoryUpdateDto)
        {
            Category category = categoryRepository.GetByID(categoryUpdateDto.Id);

            if (category == null)
            {
                throw new NullReferenceException("Category with given ID doesn't exist");
            }
            if (categoryRepository.GetCategoryByName(categoryUpdateDto.CategoryName) != null)
            {
                throw new NullReferenceException("Category with given name already exists.");
            }

            category.CategoryName = categoryUpdateDto.CategoryName;

            categoryRepository.Update(category);
            categoryRepository.Save();

            return category;
        }

        public Category Delete(Guid ID)
        {
            Category category = categoryRepository.Delete(ID);
            categoryRepository.Save();
            return category;
        }
    }
}
