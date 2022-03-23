using Microsoft.EntityFrameworkCore;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.CountryRepo
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository()
        {

        }

        public CountryRepository(timesheet_dbContext context) : base(context)
        {

        }

        new public Country GetByID(Guid ID)
        {
            return table
                .Where(p => p.Id == ID)
                .FirstOrDefault();
        }

        public override Country Delete(Guid ID)
        {
            Country? country = table.Find(ID);
            if (country != null)
            {
                country.DeletedDate = DateTime.UtcNow;
                context.Entry(country).State = EntityState.Modified;
                return country;
            }
            throw new NullReferenceException("There is no Country with given ID.");
            //var residenceType = await context.Countries.Include(c => c.Users).FirstOrDefaultAsync(i => i.PropertyGroupName == name);

        }

        public Country GetCountryByName(string name)
        {
           return table
                .AsNoTracking()
                .Where(x => x.CountryName == name)
                .FirstOrDefault();
        }
    }
}
