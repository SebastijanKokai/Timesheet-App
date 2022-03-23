using Microsoft.EntityFrameworkCore;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IGenericObject
    {
        public timesheet_dbContext context;
        public DbSet<T> table;

        public Repository()
        {
            this.context = new timesheet_dbContext();
            table = context.Set<T>();
        }

        public Repository(timesheet_dbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public IList<T> GetAll() 
        {
            return table.ToList();
        }

        public T GetByID(Guid ID)
        {
            return table.Find(ID);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            //context.Entry(obj).State = EntityState.Detached;
            context.Entry(obj).State = EntityState.Modified;
        }

        public virtual T Delete(Guid ID)
        {
            T existing = table.Find(ID);
            if (existing != null)
            {
                table.Remove(existing);
                return existing;
            }
            return null;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
