using Microsoft.EntityFrameworkCore;
using Timesheet_API.Models.Data;
using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.UserRepo
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository()
        {

        }

        public UserRepository(timesheet_dbContext context) : base(context)
        {

        }

        new public IList<User> GetAll()
        {
            return table.Include(t => t.Role).ToList();
        }

        new public User GetByID(Guid ID)
        {
            return table.AsNoTracking().Where(u => u.Id == ID).FirstOrDefault();
        }

        public override User Delete(Guid ID)
        {
            User? user = table.Find(ID);
            if (user != null)
            {
                user.DeletedDate = DateTime.UtcNow;
                context.Entry(user).State = EntityState.Modified;
                return user;
            }
            throw new NullReferenceException("There is no User with given ID.");
        }

        public User GetUserByUsername(string username)
        {
            User user = table.Where(x => x.Username == username).FirstOrDefault();
            return user;
        }
    }
}
