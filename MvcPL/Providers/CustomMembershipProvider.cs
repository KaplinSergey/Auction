using BLL.Interfaces;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Services;
using Ninject;
using DependencyResolver;
using System;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;


namespace MvcPL.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {
        private IKernel kernel;
        public MembershipUser CreateUser(string email, string password, string name)
        {
            MembershipUser membershipUser = GetUser(email, false);
            if (membershipUser != null)
            {
                return null;
            }
            var user = new UserEntity { Name = name, Email = email, Password = Crypto.HashPassword(password), CreationDate = DateTime.Now, RoleId=2 };
            kernel = new StandardKernel();
            kernel.ConfigurateResolverWeb();
            var userService = kernel.Get<IUserService>();
            var roleService = kernel.Get<IRoleService>();
            var role = roleService.GetRoleByName("User");
            if (role != null)
            {
                user.Role = role;
            }
            userService.CreateUser(user);
            membershipUser = GetUser(email, false);
            return membershipUser;
        }

        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            kernel = new StandardKernel();
            kernel.ConfigurateResolverWeb();
            var userService = kernel.Get<IUserService>();
            var user = userService.GetUserByEmail(email);
            if (user == null) return null;
            var memberUser = new MembershipUser("CustomMembershipProvider", user.Name, null, null, null, null, false, false, user.CreationDate,
                DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
            return memberUser;
        }

        public override bool ValidateUser(string email, string password)
        {
            kernel = new StandardKernel();
            kernel.ConfigurateResolverWeb();
            var userService = kernel.Get<IUserService>();
            var user = userService.GetUserByEmail(email); ;
            if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
            {              
                return true;
            }
            return false;
        }

        #region Stabs
        public override bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            kernel = new StandardKernel();
            kernel.ConfigurateResolverWeb();
            var userService = kernel.Get<IUserService>();
            var user = userService.GetUserByEmail(email); ;
            if (user != null && Crypto.VerifyHashedPassword(user.Password, oldPassword))
            {
                user.Password = Crypto.HashPassword(newPassword);
                userService.UpdateUser(user);
                return true;
            }
            return false;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
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
        #endregion
    }
}