using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using RoamLab.BO;
using RoamLab.DAL.Interface;

namespace RoamLab.DAL
{
    public class RoleUserDAL : IRole
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

        public IEnumerable<RoleUserDAL> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleUser> GetAllUserRolebyUserID(int UserID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strsq = @"SELECT * FROM RoleUser                                
                                WHERE UserID = @UserID";
                var param = new
                {
                    UserID = UserID,
                };
                var result = conn.Query<RoleUser>(strsq, param);
                return result;
            }
        }

        public void Insert(RoleUserDAL entity)
        {
            throw new NotImplementedException();
        }

        public void Update(RoleUserDAL entity)
        {
            throw new NotImplementedException();
        }
    }
}
