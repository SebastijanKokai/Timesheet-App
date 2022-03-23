using Timesheet_API.Models.Dto.ClientDtos;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Services.ClientServices
{
    public interface IClientServices : IServices<Client>
    {
        public Client Create(ClientPostDto clientPostDto);
        public Client Update(ClientUpdateDto clientUpdateDto);
    }
}
