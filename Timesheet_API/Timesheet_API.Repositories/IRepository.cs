using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories
{
    public interface IRepository<T> : IDisposable where T : class, IGenericObject
    {
        IList<T> GetAll();
        T GetByID(Guid ID);
        void Insert(T obj);
        T Delete(Guid ID);
        void Update(T obj);
        void Save();
    }
}
