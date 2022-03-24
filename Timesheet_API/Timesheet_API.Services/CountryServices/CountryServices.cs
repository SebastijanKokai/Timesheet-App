using Timesheet_API.Models;
using Timesheet_API.Models.CustomExceptions;
using Timesheet_API.Models.Dto.CountryDtos;
using Timesheet_API.Models.Models;
using Timesheet_API.Repositories.CountryRepo;

namespace Timesheet_API.Services.CountryServices
{
    public class CountryServices : ICountryServices
    {
        private ICountryRepository countryRepository;

        public CountryServices(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public IList<Country> FindAll()
        {
            return countryRepository.GetAll();
        }

        public Country FindByID(Guid ID)
        {
            return countryRepository.GetByID(ID);
        }

        public Country Create(CountryDto countryDto)
        {
            if (countryRepository.GetCountryByName(countryDto.CountryName) != null)
            {
                throw new ObjectAlreadyExistsInDatabaseException("Country name already exists.");
            }

            Country country = new Country();
            country.Id = Guid.NewGuid();
            country.CountryName = countryDto.CountryName;
            country.DeletedDate = null;

            countryRepository.Insert(country);
            countryRepository.Save();

            return country;
        }

        public CountryDto[] CreateMany(CountryDto[] countryDtos)
        {
            for(int i = 0; i < countryDtos.Length; i++)
            {
                Create(countryDtos[i]);
            }
            return countryDtos;
        }

        public Country Update(CountryUpdateDto countryUpdateDto)
        {
            Country country = countryRepository.GetByID(countryUpdateDto.Id);

            if (country == null)
            {
                throw new NullReferenceException("Country with given ID doesn't exist");
            }
            if (countryRepository.GetCountryByName(countryUpdateDto.CountryName) != null)
            {
                throw new NullReferenceException("Country with given name already exists.");
            }

            country.CountryName = countryUpdateDto.CountryName;

            countryRepository.Update(country);
            countryRepository.Save();

            return country;
        }

        public Country Delete(Guid ID)
        {

            Country country = countryRepository.Delete(ID);
            countryRepository.Save();
            return country;
        }
    }
}
