using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Numerics;
using System.Text;
using Dapper;
using RoamLab.BO;
using RoamLab.DAL.Interface;

namespace RoamLab.DAL
{
    public class VacationPlanDAL : IVacationPlan
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

        public IEnumerable<VacationPlan> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(VacationPlan entity)
        {
            throw new NotImplementedException();
        }

        public void TransactionInsert(VacationPlan Plan)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string vacationPlanQuery = @"
                INSERT INTO VacationPlan (UserID, Name, Description)
                VALUES (@UserID, @Name, @Description);
                SELECT CAST(SCOPE_IDENTITY() as int)"
                        ;

                        var parameters = new
                        {
                            UserID = Plan.UserID,
                            Name = Plan.Name,
                            Description = Plan.Description,
                            
                        };

                        int planId = conn.ExecuteScalar<int>(vacationPlanQuery, parameters, transaction);

                        // Assuming you want to set the generated PlanID back to the object
                        Plan.PlanID = planId;

                        // Insert plan items
                        foreach (var planItem in Plan.PlanItems)
                        {
                            string planItemQuery = @"
                    INSERT INTO PlanItem (PlanID, PlaceID, DatePlace)
                    VALUES (@PlanID, @PlaceID, @DatePlace)" 
                            ;
                            //StringBuilder
                            var param = new
                            {
                                PlanID = planId,
                                PlaceID = planItem.PlaceID,
                                DatePlace = planItem.DatePlace
                            };

                            conn.Execute(planItemQuery, param, transaction);
                        }

                        transaction.Commit();
                        conn.Close();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw; // Re-throwing the exception to maintain the original exception chain
                    }
                }
            }

        }

        public void Update(VacationPlan entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VacationPlan> GetVacationPlanByUserID(int userID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from VacationPlan where UserID = @UserID";
                var param = new { UserID = userID };
                var result = conn.Query<VacationPlan>(strSql, param);
                return result;
            }
        }

        public VacationPlan GetVacationPlanAndPlanItemByPlanID(int planID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string vacationPlanQuery = @"select * from VacationPlan where PlanID = @PlanID";

                        var parameters = new
                        { PlanID = planID,};
                        var result = conn.QuerySingleOrDefault<VacationPlan>(vacationPlanQuery, parameters,transaction);
                        string planItemQuery = @"select * from PlanItem where PlanID = @PlanID";

                        var param = new
                            {PlanID = planID};

                        var results = conn.Query<PlanItem>(planItemQuery, param, transaction);

                        var placedal = new PlaceDAL();
                        foreach(var item in results)
                        {
                         item.PlacebyID = placedal.GetPlaceByID(item.PlaceID);   
                        }
                        
                        var VacationPlan = new VacationPlan 
                        {
                            PlanID = planID,
                            Name = result.Name,
                            Description = result.Description,
                            CreatedDate = result.CreatedDate,
                            IsPublic = result.IsPublic,
                            UserID = result.UserID,
                            PlanItems = results
                        };

                        transaction.Commit();
                        conn.Close();
                        return VacationPlan;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw; // Re-throwing the exception to maintain the original exception chain
                    }
                }
            }
        }
    }
}
