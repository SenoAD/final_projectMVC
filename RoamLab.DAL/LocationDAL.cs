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
    public class LocationDAL : ILocation
    {
        private string GetConnectionString()
        {
            //return @"Data Source=ACTUAL;Initial Catalog=LatihanDb;Integrated Security=True;TrustServerCertificate=True";
            return ConfigurationManager.ConnectionStrings["MyDbConnectionString"].ConnectionString;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strsql = @"SELECT * FROM Location ORDER BY City";
                var results = conn.Query<Location>(strsql);
                return results;
            }
        }

        public void Insert(Location entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Location entity)
        {
            throw new NotImplementedException();
        }
    }
}
