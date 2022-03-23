using Timesheet_API.Models.CustomExceptions;
using Timesheet_API.Models.Dto.RoleDtos;
using Timesheet_API.Models.Models;
using Timesheet_API.Repositories.RoleRepo;

namespace Timesheet_API.Services.RoleServices
{
    public class RoleServices : IRoleServices
    {
        IRoleRepository roleRepository;

        public RoleServices(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public IList<Role> FindAll()
        {
            return roleRepository.GetAll();
        }

        public Role FindByID(Guid ID)
        {
            return roleRepository.GetByID(ID);
        }

        public Role Create(RoleDto roleDto)
        {
            if (roleDto == null)
            {
                return null;
            }

            Role role = new Role();
            if (roleRepository.GetRoleByName(roleDto.RoleName) != null)
            {
                throw new ObjectAlreadyExistsInDatabaseException("Role name already exists.");
            }

            role.Id = Guid.NewGuid();
            role.RoleName = roleDto.RoleName;

            roleRepository.Insert(role);
            roleRepository.Save();

            return role;
        }

        public Role Update(RoleUpdateDto roleUpdateDto)
        {
            Role role = roleRepository.GetByID(roleUpdateDto.Id);

            if (role == null)
            {
                throw new NullReferenceException("Role with given ID does not exist.");
            }

            role.RoleName = roleUpdateDto.RoleName;

            roleRepository.Update(role);
            roleRepository.Save();

            return role;
        }

        public Role Delete(Guid ID)
        {
            Role role = roleRepository.Delete(ID);
            roleRepository.Save();
            return role;
        }


    }
}
