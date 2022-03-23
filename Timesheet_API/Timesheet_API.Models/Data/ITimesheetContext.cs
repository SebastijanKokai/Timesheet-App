using Microsoft.EntityFrameworkCore;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Models.Data
{
    public interface ITimesheetContext : IDisposable
    {
        public DbSet<Country> Countries { get; set; }

        int SaveChanges();
        void MarkAsModified(Country country);
    }
}
