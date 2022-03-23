using Timesheet_API.Models.Models;

namespace Timesheet_API.Services
{
    public interface IServices<T> where T : class, IGenericObject
    {
        IList<T> FindAll();
        T FindByID(Guid ID);
        T Delete(Guid ID);
    }
}
