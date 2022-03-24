using AutoMapper;
using Timesheet_API.Models.Dto.ClientDtos;
using Timesheet_API.Models.Helpers;
using Timesheet_API.Models.Models;
using Timesheet_API.Models.Parameters;
using Timesheet_API.Repositories.ClientRepo;
using Timesheet_API.Repositories.CountryRepo;

namespace Timesheet_API.Services.ClientServices
{
    public class ClientServices : IClientServices
    {
        private IClientRepository clientRepository;
        private ICountryRepository countryRepository;
        private IMapper mapper;

        public ClientServices(IClientRepository clientRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.countryRepository = countryRepository;
            this.mapper = mapper;
        }

        public IList<Client> FindAll()
        {
            return clientRepository.GetAll();
        }

        public PagedList<Client> FindAll(ClientParameters clientParameters)
        {
            return clientRepository.GetAll(clientParameters);
        }

        public Client FindByID(Guid ID)
        {
            return clientRepository.GetByID(ID);
        }

        public Client Create(ClientPostDto clientPostDto)
        {
            Country country = countryRepository.GetByID(clientPostDto.CountryId);

            if (country == null)
            {
                throw new NullReferenceException("Country does not exist in database. Create the country first.");
            }

            var client = mapper.Map<Client>(clientPostDto);
            client.Id = Guid.NewGuid();
            client.CountryId = country.Id;

            clientRepository.Insert(client);

            clientRepository.Save();
            return client;
        }

        public Client Update(ClientUpdateDto clientUpdateDto)
        {

            Client client = clientRepository.GetByID(clientUpdateDto.Id);

            if (client == null)
            {
                throw new NullReferenceException("Client with given ID does not exist.");
            }

            Country country = countryRepository.GetByID(clientUpdateDto.CountryId);

            if (country == null)
            {
                throw new NullReferenceException("Country does not exist in database. Create the country first.");
            }

            client = mapper.Map<Client>(clientUpdateDto);
            client.CountryId = country.Id;

            clientRepository.Update(client);
            clientRepository.Save();

            return client;
        }

        public Client Delete(Guid ID)
        {
            Client client = clientRepository.Delete(ID);
            if(client == null)
            {
                throw new NullReferenceException("Client with given ID does not exist.");
            }
            clientRepository.Save();
            return client;
        }
    }
}
