using AutoMapper;
using Timesheet_API.Models.Dto.ProjectDtos;
using Timesheet_API.Models.Helpers;
using Timesheet_API.Models.Models;
using Timesheet_API.Models.Parameters;
using Timesheet_API.Repositories.ClientRepo;
using Timesheet_API.Repositories.ProjectRepo;

namespace Timesheet_API.Services.ProjectServices
{
    public class ProjectServices : IProjectServices
    {
        private IProjectRepository projectRepository;
        private IClientRepository clientRepository;
        private IMapper mapper;

        public ProjectServices(IProjectRepository projectRepository, IClientRepository clientRepository, IMapper mapper)
        {
            this.projectRepository = projectRepository;
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        public IList<Project> FindAll()
        {
            return projectRepository.GetAll();
        }

        public PagedList<Project> FindAll(ProjectParameters projectParameters)
        {
            return projectRepository.GetAll(projectParameters);
        }

        public List<string> FindFirstLettersOfProjectsThatExist()
        {
            return projectRepository.GetFirstLettersOfObjectsArray();
        }

        public Project FindByID(Guid ID)
        {
            return projectRepository.GetByID(ID);
        }

        public Project Create(ProjectPostDto projectPostDto)
        {
            Client client = clientRepository.GetByID(projectPostDto.ClientID);

            if (client == null)
            {
                throw new NullReferenceException("Client doesn't exist in the database.");
            }

            Project project = mapper.Map<Project>(projectPostDto);
            project.Id = Guid.NewGuid();
            project.ClientId = client.Id;

            projectRepository.Insert(project);
            client.Projects.Add(project);

            projectRepository.Save();

            return project;
        }

        public Project Update(ProjectUpdateDto projectUpdateDto)
        {
            Project project = projectRepository.GetByID(projectUpdateDto.Id);

            if (project == null)
            {
                throw new NullReferenceException("Project doesn't exist in the database.");
            }

            Client client = clientRepository.GetByID(projectUpdateDto.ClientID);

            if (client == null)
            {
                throw new NullReferenceException("Client doesn't exist in the database.");
            }

            project = mapper.Map<Project>(projectUpdateDto);
            project.Client = client;
            project.ClientId = client.Id;

            projectRepository.Update(project);
            projectRepository.Save();

            return project;
        }

        public Project Delete(Guid ID)
        {
            Project project = projectRepository.Delete(ID);
            if (project == null)
            {
                throw new NullReferenceException("Project with given ID does not exist in the database.");
            }
            projectRepository.Save();
            return project;
        }

        
    }
}
