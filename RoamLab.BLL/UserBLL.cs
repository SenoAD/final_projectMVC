using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BLL.DTO;
using RoamLab.BLL.Interface;
using RoamLab.BO;
using RoamLab.DAL;
using RoamLab.DAL.Interface;

namespace RoamLab.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUser userDAL;
        private readonly IRole roleUserDal;
        public UserBLL()
        {
            userDAL = new UserDAL();
            roleUserDal = new RoleUserDAL();
        }
        public void Insert(UserCreateDTO entity)
        {
            if (string.IsNullOrEmpty(entity.Username))
            {
                throw new ArgumentException("Username is required");
            }
            if (string.IsNullOrEmpty(entity.Password))
            {
                throw new ArgumentException("Password is required");
            }
            if (string.IsNullOrEmpty(entity.FirstName))
            {
                throw new ArgumentException("First Name is required");
            }
            if (string.IsNullOrEmpty(entity.LastName))
            {
                throw new ArgumentException("Last Name is required");
            }
            if (string.IsNullOrEmpty(entity.Location))
            {
                throw new ArgumentException("Location is required");
            }
            if (string.IsNullOrEmpty(entity.Email))
            {
                throw new ArgumentException("Email is required");
            }
            if (entity.Password != entity.Repassword)
            {
                throw new ArgumentException("Password and Re-Password must be same");
            }

            try
            {
                var newUser = new User
                {
                    Username = entity.Username,
                    Password = Helper.GetHash(entity.Password),
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Location = entity.Location,
                    Email = entity.Email
                };
                userDAL.Insert(newUser);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("2627"))
                {
                    throw new ArgumentException("Username already exists");
                }

                throw new ArgumentException(ex.Message);
            }
        }

        public LoginUserDTO Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username is required");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password is required");
            }
            try
            {
                var result = userDAL.Login(username, Helper.GetHash(password));
                if (result == null)
                {
                    throw new ArgumentException("Username or Password is wrong");
                }
                var result2 = roleUserDal.GetAllUserRolebyUserID(result.UserID);
                var rolesUser = new List<RoleUserDTO>();

                foreach (var item in result2)
                {
                    var roleTemp = new RoleUserDTO
                    {
                        RoleID = item.RoleID,
                        UserID = item.UserID,
                    };
                    rolesUser.Add(roleTemp);
                }

                LoginUserDTO userDTO = new LoginUserDTO
                {
                    UserID = result.UserID,
                    Username = result.Username,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Location = result.Location,
                    Email = result.Email,
                    Password = result.Password,
                    RoleUsers = rolesUser
                };

                return userDTO;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}

