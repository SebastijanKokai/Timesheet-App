using Timesheet_API.Models.Dto.UserProjectDtos;
using Timesheet_API.Models.Models;
using Timesheet_API.Repositories.ProjectRepo;
using Timesheet_API.Repositories.UserProjectRepo;
using Timesheet_API.Repositories.UserRepo;

namespace Timesheet_API.Services.UserProjectServices
{
    public class UserProjectServices : IUserProjectServices
    {
        IUserProjectRepository userProjectRepository;
        IUserRepository userRepository;
        IProjectRepository projectRepository;

        public UserProjectServices(IUserProjectRepository userProjectRepository, IUserRepository userRepository, IProjectRepository projectRepository)
        {
            this.userProjectRepository = userProjectRepository;
            this.userRepository = userRepository;
            this.projectRepository = projectRepository;
        }
        public IList<UserProject> FindAll()
        {
            return userProjectRepository.GetAll();
        }

        public UserProject FindByID(UserProjectDto userProjectDto)
        {
            return userProjectRepository.GetByID(userProjectDto.UserID, userProjectDto.ProjectID);
        }

        public UserProject Create(UserProjectDto userProjectDto)
        {
            Project project = projectRepository.GetByID(userProjectDto.ProjectID);

            if (project == null)
            {
                throw new NullReferenceException("Project does not exist in the database.");
            }

            User user = userRepository.GetByID(userProjectDto.UserID);

            if (user == null)
            {
                throw new NullReferenceException("User does not exist in the database.");
            }

            UserProject userProject = new UserProject();

            userProject.ProjectId = project.Id;
            userProject.UserId = user.Id;

            userProjectRepository.Insert(userProject);
            userProjectRepository.Save();

            return userProject;
        }

        public UserProject Delete(UserProjectDto userProjectDto)
        {
            UserProject userProject = userProjectRepository.Delete(userProjectDto.UserID, userProjectDto.ProjectID);
            userProjectRepository.Save();
            return userProject;
        }
    }
}
