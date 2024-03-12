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
    public class PlaceDAL : IPlace
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

        public IEnumerable<Place> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strsql = @"SELECT * FROM Place ORDER BY LocationID";
                var results = conn.Query<Place>(strsql);
                return results;
            }
        }

        public void Insert(Place entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Place entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Place> GetPlaceByLocationID(int locationID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Place where LocationID = @LocationID";
                var param = new { LocationID = locationID };
                var result = conn.Query<Place>(strSql, param);
                return result;
            }
        }
    }
}
