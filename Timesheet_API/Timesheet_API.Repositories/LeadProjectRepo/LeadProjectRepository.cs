using Microsoft.EntityFrameworkCore;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.LeadProjectRepo
{
    public class LeadProjectRepository : ILeadProjectRepository
    {

        public timesheet_dbContext context;
        public DbSet<LeadProject> table;

        public LeadProjectRepository()
        {
            this.context = new timesheet_dbContext();
            table = context.Set<LeadProject>();
        }

        public LeadProjectRepository(timesheet_dbContext context)
        {
            this.context = context;
            table = context.Set<LeadProject>();
        }

        public IList<LeadProject> GetAll()
        {
            return table.ToList();
        }

        public LeadProject GetByID(Guid UserID, Guid ProjectID)
        {
            return table.Find(UserID, ProjectID);
        }

        public void Insert(LeadProject obj)
        {
            table.Add(obj);
        }
        public void Update(LeadProject obj)
        {
            context.Entry(obj).State = EntityState.Modified;
        }

        public LeadProject Delete(Guid UserID, Guid ProjectID)
        {
            LeadProject existing = table.Find(UserID, ProjectID);
            if (existing != null)
            {
                existing.DeletedDate = DateTime.UtcNow;
                context.Entry(existing).State = EntityState.Modified;
                return existing;
            }
            throw new NullReferenceException("No LeadProject relationship with given ID's");
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
