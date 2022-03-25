using Timesheet_API.Models.Dto.ClientDtos;
using Timesheet_API.Models.Helpers;
using Timesheet_API.Models.Models;
using Timesheet_API.Models.Parameters;

namespace Timesheet_API.Services.ClientServices
{
    public interface IClientServices : IServices<Client>
    {
        public PagedList<Client> FindAll(ClientParameters clientParameters);
        public Client Create(ClientPostDto clientPostDto);
        public Client Update(ClientUpdateDto clientUpdateDto);
        public List<string> FindFirstLettersOfClientsThatExist();
    }
}
