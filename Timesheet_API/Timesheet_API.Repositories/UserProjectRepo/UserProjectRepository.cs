using Microsoft.EntityFrameworkCore;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.UserProjectRepo
{
    public class UserProjectRepository : IUserProjectRepository, IDisposable
    {
        public timesheet_dbContext context;
        public DbSet<UserProject> table;

        public UserProjectRepository()
        {
            this.context = new timesheet_dbContext();
            table = context.Set<UserProject>();
        }

        public UserProjectRepository(timesheet_dbContext context)
        {
            this.context = context;
            table = context.Set<UserProject>();
        }

        public IList<UserProject> GetAll()
        {
            return table.ToList();
        }

        public UserProject GetByID(Guid UserID, Guid ProjectID)
        {
            return table.Include(u => u.User).Include(p => p.Project).Where(p => p.UserId == UserID && p.ProjectId == ProjectID).FirstOrDefault();
        }

        public void Insert(UserProject obj)
        {
            table.Add(obj);
        }
        public void Update(UserProject obj)
        {
            context.Entry(obj).State = EntityState.Modified;
        }

        public UserProject Delete(Guid UserID, Guid ProjectID)
        {
            UserProject existing = table.Find(UserID, ProjectID);
            if (existing != null)
            {
                existing.DeletedDate = DateTime.UtcNow;
                context.Entry(existing).State = EntityState.Modified;
                return existing;
            }
            throw new NullReferenceException("No UserProject relationship with given ID's");
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
