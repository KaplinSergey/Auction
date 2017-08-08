using System.Collections.Generic;
using BLL.Interfaces.Entities;

namespace BLL.Interfaces.Services
{
    public interface IRoleService
    {
        RoleEntity GetRoleEntity(int id);
        IEnumerable<RoleEntity> GetAllRoleEntities();
        void CreateRole(RoleEntity role);
        void DeleteRole(RoleEntity role);
        void UpdateRole(RoleEntity role);
        RoleEntity GetRoleByName(string name);
    }
}
