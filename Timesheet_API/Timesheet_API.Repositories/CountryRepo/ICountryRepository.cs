using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.CountryRepo
{
    public interface ICountryRepository : IRepository<Country>
    {
        public Country GetCountryByName(string name);
    }
}
