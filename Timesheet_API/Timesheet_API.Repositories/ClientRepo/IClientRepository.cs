using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.ClientRepo
{
    public interface IClientRepository : IRepository<Client>
    {
        public Client GetClientByName(string name);
    }
}
