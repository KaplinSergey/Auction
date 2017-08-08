using System;
using System.Collections.Generic;
using BLL.Interfaces.Services;
using BLL.Interfaces.Entities;
using BLL.Mappers;
using DAL.Interfaces.Interfaces;
using System.Linq;

namespace BLL.Services
{
    public class RoleService:IRoleService
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;
        public RoleService(IUnitOfWork uow, IRoleRepository repository)
        {
            this.uow = uow;
            this.roleRepository = repository;
        }
        public RoleEntity GetRoleEntity(int id)
        {
            return roleRepository.GetById(id).ToBllRole();
        }

        public IEnumerable<RoleEntity> GetAllRoleEntities()
        {
            return roleRepository.GetAll().Select(role => role.ToBllRole());
        }

        public RoleEntity GetRoleByName(string name)
        {
            return roleRepository.GetRoleByName(name).ToBllRole();
        }

        public void CreateRole(RoleEntity role)
        {
            roleRepository.Create(role.ToDalRole());
            uow.Commit();
        }

        public void DeleteRole(RoleEntity role)
        {
            roleRepository.Delete(role.ToDalRole());
            uow.Commit();
        }

        public void UpdateRole(RoleEntity role)
        {
            roleRepository.Update(role.ToDalRole());
            uow.Commit();
        }
    }
}
