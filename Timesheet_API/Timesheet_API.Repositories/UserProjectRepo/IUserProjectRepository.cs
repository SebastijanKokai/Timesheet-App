using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.UserProjectRepo
{
    public interface IUserProjectRepository
    {
        IList<UserProject> GetAll();
        UserProject GetByID(Guid UserID, Guid ProjectID);
        void Insert(UserProject obj);
        void Update(UserProject obj);
        UserProject Delete(Guid UserID, Guid ProjectID);
        void Save();
    }
}
