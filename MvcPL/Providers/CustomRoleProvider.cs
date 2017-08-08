using BLL.Interfaces;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using Ninject;
using DependencyResolver;

namespace MvcPL.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private IKernel kernel;


        public override string[] GetAllRoles()
        {
            kernel = new StandardKernel();
            kernel.ConfigurateResolverWeb();
            var roleService = kernel.Get<IRoleService>();
            return roleService.GetAllRoleEntities().Select(r => r.Name).ToArray();
        }

        public override void CreateRole(string roleName)
        {
            var newRole = new RoleEntity { Name = roleName };
            kernel = new StandardKernel();
            kernel.ConfigurateResolverWeb();
            var roleService = kernel.Get<IRoleService>();
            roleService.CreateRole(newRole);
        }

        public override string[] GetRolesForUser(string email)
        {
            kernel = new StandardKernel();
            kernel.ConfigurateResolverWeb();
            var userService = kernel.Get<IUserService>();            
            var roles = new string[] { };
            var user = userService.GetUserByEmail(email);
            if (user == null) return roles;
            var userRole = user.Role;
            if (userRole != null)
            {
                roles = new string[] { userRole.Name };
            }
            return roles;
        }


        public override bool IsUserInRole(string email, string roleName)
        {
            kernel = new StandardKernel();
            kernel.ConfigurateResolverWeb();
            var userService = kernel.Get<IUserService>();
            var roleService = kernel.Get<IRoleService>();
            //IUserService userService = (IUserService)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(IUserService));
            var user = userService.GetUserByEmail(email);
            if (user == null) return false;
            var role = roleService.GetRoleEntity(user.Id);

            if (role != null && role.Name == roleName)
            {
                return true;
            }
            return false;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
    }
}