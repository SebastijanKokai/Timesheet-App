using Timesheet_API.Models.Models;

namespace Timesheet_API.Repositories.UserRepo
{
    public interface IUserRepository : IRepository<User>
    {
        public User GetUserByUsername(string username);
    }
}
