using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using RoamLab.BO;
using RoamLab.DAL.Interface;
using static Dapper.SqlMapper;

namespace RoamLab.DAL
{
    public class PlaceDAL : IPlace
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

        public void InsertPlaceHotel(Place place)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {

                        var strsql = @"INSERT INTO Place(Name, Address, PhoneNumber, LocationID, CategoryID) 
                                 VALUES(@Name, @Address, @PhoneNumber, @LocationID, @CategoryID);
                                 SELECT CAST(SCOPE_IDENTITY() as int)";
                        var param = new
                        {
                            Name = place.Name,
                            Address = place.Address,
                            PhoneNumber = place.PhoneNumber,
                            LocationID = place.LocationID,
                            CategoryID = place.CategoryID,
                        };

                        int placeId = conn.ExecuteScalar<int>(strsql, param, transaction);
                        //int result = conn.Execute(strsql, param);
                        string strsql2 = @"INSERT INTO Hotel(PlaceID, Facilitation)
                                               VALUES (@PlaceID, @Facilitation)";

                        var param2 = new
                        {
                            PlaceID = placeId,
                            Facilitation = place.Hotel.Facilitation,
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

        public void InsertPlaceAttraction(Place place)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {

                        var strsql = @"INSERT INTO Place(Name, Address, PhoneNumber, LocationID, CategoryID) 
                                 VALUES(@Name, @Address, @PhoneNumber, @LocationID, @CategoryID);
                                 SELECT CAST(SCOPE_IDENTITY() as int)";
                        var param = new
                        {
                            Name = place.Name,
                            Address = place.Address,
                            PhoneNumber = place.PhoneNumber,
                            LocationID = place.LocationID,
                            CategoryID = place.CategoryID,
                        };

                        int placeId = conn.ExecuteScalar<int>(strsql, param, transaction);
                        //int result = conn.Execute(strsql, param);
                        string strsql2 = @"INSERT INTO Attraction(PlaceID, Type, OpeningHours, AdmissionFee)
                                               VALUES (@PlaceID, @Type1, @OpeningHours, @AdmissionFee)";

                        var param2 = new
                        {
                            PlaceID = placeId,
                            Type1 = place.Attraction.Type,
                            OpeningHours = place.Attraction.OpeningHours,
                            AdmissionFee = place.Attraction.AdmissionFee,
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

        public void InsertPlaceRestaurant(Place place)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {

                        var strsql = @"INSERT INTO Place(Name, Address, PhoneNumber, LocationID, CategoryID) 
                                 VALUES(@Name, @Address, @PhoneNumber, @LocationID, @CategoryID);
                                 SELECT CAST(SCOPE_IDENTITY() as int)";
                        var param = new
                        {
                            Name = place.Name,
                            Address = place.Address,
                            PhoneNumber = place.PhoneNumber,
                            LocationID = place.LocationID,
                            CategoryID = place.CategoryID,
                        };

                        int placeId = conn.ExecuteScalar<int>(strsql, param, transaction);
                        //int result = conn.Execute(strsql, param);
                        string strsql2 = @"INSERT INTO Restaurant(PlaceID, CuisineType, PriceRange)
                                               VALUES (@PlaceID, @CuisineType, @PriceRange)";

                        var param2 = new
                        {
                            PlaceID = placeId,
                            CuisineType = place.Restaurant.CuisineType,
                            PriceRange = place.Restaurant.PriceRange,
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

        public Place GetPlaceByID(int placeID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strsql = @"SELECT * FROM Place WHERE PlaceID = @PlaceID";
                var results = conn.QueryFirstOrDefault<Place>(strsql, new {PlaceID = placeID });
                return results;
            }
        }
    }
}
