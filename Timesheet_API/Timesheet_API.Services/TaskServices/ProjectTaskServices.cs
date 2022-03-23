using AutoMapper;
using Timesheet_API.Models.Dto.ProjectTaskDtos;
using Timesheet_API.Models.Models;
using Timesheet_API.Repositories.CategoryRepo;
using Timesheet_API.Repositories.ProjectTaskRepo;
using Timesheet_API.Repositories.UserProjectRepo;

namespace Timesheet_API.Services.TaskServices
{
    public class ProjectTaskServices : IProjectTaskServices
    {
        private IProjectTaskRepository projectTaskRepository;
        private ICategoryRepository categoryRepository;
        private IUserProjectRepository userProjectRepository;
        private IMapper mapper;

        public ProjectTaskServices(IProjectTaskRepository projectTaskRepository, ICategoryRepository categoryRepository, IUserProjectRepository userProjectRepository, IMapper mapper)
        {
            this.projectTaskRepository = projectTaskRepository;
            this.categoryRepository = categoryRepository;
            this.userProjectRepository = userProjectRepository;
            this.mapper = mapper;
        }

        public IList<ProjectTask> FindAll()
        {
            return projectTaskRepository.GetAll();
        }

        public ProjectTask FindByID(Guid ID)
        {
            return projectTaskRepository.GetByID(ID);
        }

        public ProjectTask Create(ProjectTaskPostDto projectTaskPostDto)
        {
            UserProject userProject = userProjectRepository.GetByID(projectTaskPostDto.UserId, projectTaskPostDto.ProjectId);

            if (userProject == null)
            {
                throw new NullReferenceException("User or Project with given ID does not exist.");
            }

            Category category = categoryRepository.GetByID(projectTaskPostDto.CategoryId);

            if (category == null)
            {
                throw new NullReferenceException("Category with given ID does not exist.");
            }

            ProjectTask projectTask = mapper.Map<ProjectTask>(projectTaskPostDto);
            projectTask.Id = Guid.NewGuid();

            projectTaskRepository.Insert(projectTask);

            projectTaskRepository.Save();

            return projectTask;
        }

        public ProjectTask Update(ProjectTaskUpdateDto projectTaskUpdateDto)
        {
            ProjectTask projectTask = projectTaskRepository.GetByID(projectTaskUpdateDto.Id);

            if (projectTask == null)
            {
                throw new NullReferenceException("Task with given ID does not exist.");
            }

            projectTask = mapper.Map<ProjectTask>(projectTaskUpdateDto);

            projectTaskRepository.Update(projectTask);
            projectTaskRepository.Save();

            return projectTask;
        }

        public ProjectTask Delete(Guid ID)
        {
            ProjectTask projectTask = projectTaskRepository.Delete(ID);
            projectTaskRepository.Save();
            return projectTask;
        }

        
    }
}
