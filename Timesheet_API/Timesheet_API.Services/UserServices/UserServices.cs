using Timesheet_API.Models.Data;
using Timesheet_API.Models.Dto.UserDtos;
using Timesheet_API.Models.Models;
using Timesheet_API.Repositories.UserRepo;
using Timesheet_API.Repositories.RoleRepo;
using AutoMapper;

namespace Timesheet_API.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;
        private IMapper mapper;

        public UserServices(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.mapper = mapper;
        }

        public IList<User> FindAll()
        {
            return userRepository.GetAll();
        }

        public User FindByID(Guid ID)
        {
            return userRepository.GetByID(ID);
        }

        public User Create(UserPostDto userPostDto)
        {
            Role role = roleRepository.GetRoleByName(userPostDto.RoleName);

            if (role == null)
            {
                throw new NullReferenceException("Role with given name does not exist in the database.");
            }

            User user = mapper.Map<User>(userPostDto);
            user.Id = Guid.NewGuid();
            user.UserPassword = "InitialPassword";
            user.RoleId = role.Id;
            user.Role = role;

            userRepository.Insert(user);
            userRepository.Save();
            return user;
        }

        public User Update(UserUpdateDto userUpdateDto)
        {
            Role role = roleRepository.GetRoleByName(userUpdateDto.RoleName);

            if (role == null)
            {
                throw new NullReferenceException("Role with given name does not exist in the database.");
            }

            User user = userRepository.GetByID(userUpdateDto.Id);

            if (user == null)
            {
                throw new NullReferenceException("User with given username does not exist in the database.");
            }

            user = mapper.Map<User>(userUpdateDto);

            user.RoleId = role.Id;
            user.Role = role;

            userRepository.Update(user);
            userRepository.Save();

            return user;
        }

        public User Delete(Guid ID)
        {
            User user = userRepository.Delete(ID);
            userRepository.Save();
            return user;
        }
    }
}
