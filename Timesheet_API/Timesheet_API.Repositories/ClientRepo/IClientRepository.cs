using Timesheet_API.Models.Helpers;
using Timesheet_API.Models.Models;
using Timesheet_API.Models.Parameters;

namespace Timesheet_API.Repositories.ClientRepo
{
    public interface IClientRepository : IRepository<Client>
    {
        public PagedList<Client> GetAll(ClientParameters clientParameters);
        public Client GetClientByName(string name);

        public List<string> GetFirstLettersOfClientsThatExist();
    }
}
