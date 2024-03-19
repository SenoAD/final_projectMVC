using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using RoamLab.BO;
using RoamLab.DAL.Interface;

namespace RoamLab.DAL
{
    public class UserDAL : IUser
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            //return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByUserID(int userID)
        {
            throw new NotImplementedException();
        }

        public void Insert(User entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {

                        var strsql = @"INSERT INTO Users(Username,Password,Email,FirstName,LastName,Location) 
                                 VALUES(@Username, @Password, @Email, @FirstName, @LastName, @Location);
                                 SELECT CAST(SCOPE_IDENTITY() as int)";
                        var param = new
                        {
                            Username = entity.Username,
                            Password = entity.Password,
                            Email = entity.Email,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            Location = entity.Location
                        };

                        int userId = conn.ExecuteScalar<int>(strsql, param, transaction);
                        //int result = conn.Execute(strsql, param);
                        string strsql2 = @"INSERT INTO RoleUser (UserID)
                                               VALUES (@UserID)";

                        var param2 = new
                        {
                            UserID = userId
                        };

                        conn.Execute(strsql2, param2, transaction);
                        transaction.Commit();
                        conn.Close();
                    }
                    catch 
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public User Login(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strsqllld = @"UPDATE Users
                                SET LastLoginDate = @lld                                 
                                WHERE Username = @Username";
                var paramlld = new
                {
                    Username = username,
                    lld = DateTime.Now.ToString()
                };
                var resultlld = conn.Execute(strsqllld, paramlld);
                var strsql = @"SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                var param = new
                {
                    Username = username,
                    Password = password
                };
                var result = conn.QueryFirstOrDefault<User>(strsql, param);
                return result;
            }
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
