using Timesheet_API.Models.Dto.CountryDtos;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Services.CountryServices
{
    public interface ICountryServices : IServices<Country>
    {
        public Country Create(CountryDto countryDto);
        public Country Update(CountryUpdateDto countryUpdateDto);
    }
}
