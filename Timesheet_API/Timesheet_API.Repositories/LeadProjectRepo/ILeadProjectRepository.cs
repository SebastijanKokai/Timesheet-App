using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.LeadProjectRepo
{
    public interface ILeadProjectRepository
    {
        IList<LeadProject> GetAll();
        LeadProject GetByID(Guid UserID, Guid ProjectID);
        void Insert(LeadProject obj);
        void Update(LeadProject obj);
        LeadProject Delete(Guid UserID, Guid ProjectID);
        void Save();
    }
}
