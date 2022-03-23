using Timesheet_API.Models.Dto.LeadProjectDtos;
using Timesheet_API.Models.Models;
using Timesheet_API.Repositories.LeadProjectRepo;
using Timesheet_API.Repositories.UserProjectRepo;

namespace Timesheet_API.Services.LeadProjectServices
{
    public class LeadProjectServices : ILeadProjectServices
    {
        private ILeadProjectRepository leadProjectRepository;
        private IUserProjectRepository userProjectRepository;

        public LeadProjectServices(ILeadProjectRepository leadProjectRepository, IUserProjectRepository userProjectRepository)
        {
            this.leadProjectRepository = leadProjectRepository;
            this.userProjectRepository = userProjectRepository;
        }

        public IList<LeadProject> FindAll()
        {
            return leadProjectRepository.GetAll();
        }

        public LeadProject FindByID(LeadProjectDto leadProjectDto)
        {
            return leadProjectRepository.GetByID(leadProjectDto.UserID, leadProjectDto.ProjectID);
        }
        public LeadProject Create(LeadProjectDto leadProjectDto)
        {
            UserProject userProject = userProjectRepository.GetByID(leadProjectDto.UserID, leadProjectDto.ProjectID);

            if (userProject == null)
            {
                throw new NullReferenceException("No given user working on given project.");
            }

            LeadProject leadProject = new LeadProject();
            leadProject.UserId = userProject.UserId;
            leadProject.ProjectId = userProject.ProjectId;


            leadProjectRepository.Insert(leadProject);
            leadProjectRepository.Save();

            return leadProject;
        }

        public LeadProject Delete(LeadProjectDto leadProjectDto)
        {
            LeadProject leadProject = leadProjectRepository.Delete(leadProjectDto.UserID, leadProjectDto.ProjectID);
            leadProjectRepository.Save();
            return leadProject;
        }

        
    }
}
