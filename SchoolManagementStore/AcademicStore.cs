using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace SchoolManagementStore
{
    public interface IAcademicStore
    {
        List<AcademicStoreInfo> GetAcademic();
        AcademicStoreInfo GetAcademicId(long AcademicId);
        AcademicStoreInfo AddAcademic(AcademicStoreInfo academic);
        AcademicStoreInfo UpdateAcademic(AcademicStoreInfo academic);
        string DeleteAcademic(long AcademicId);
    }

    public class AcademicStore : IAcademicStore
    {
        private readonly IConfiguration _iconfiguration;
        public AcademicStore(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }
        public List<AcademicStoreInfo> GetAcademic()
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                List<AcademicStoreInfo> academics = new List<AcademicStoreInfo>();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GetAcademic";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        academics.Add(new AcademicStoreInfo
                        {
                            AcademicId = Convert.ToInt64(sqlDataReader["AcademicId"]),
                            AcademicStartYear = Convert.ToInt32(sqlDataReader["AcademicStartYear"]),
                            AcademicEndYear = Convert.ToInt32(sqlDataReader["AcademicEndYear"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"]),
                        });
                    }
                    sqlConnection.Close();
                }
                return academics;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public AcademicStoreInfo GetAcademicId(long AcademicId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                AcademicStoreInfo academics = new AcademicStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GetAcademicId";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@AcademicId", AcademicId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        academics = new AcademicStoreInfo()
                        {
                            AcademicId = Convert.ToInt64(sqlDataReader["AcademicId"]),
                            AcademicStartYear = Convert.ToInt32(sqlDataReader["AcademicStartYear"]),
                            AcademicEndYear = Convert.ToInt32(sqlDataReader["AcademicEndYear"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"]),
                        };
                    }
                    sqlConnection.Close();
                }
                return academics;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public AcademicStoreInfo AddAcademic(AcademicStoreInfo academic)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_AddAcademic";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@AcademicStartYear", academic.AcademicStartYear);
                sqlCommand.Parameters.AddWithValue("@AcademicEndYear", academic.AcademicEndYear);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();
                return academic;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public AcademicStoreInfo UpdateAcademic(AcademicStoreInfo academic)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_UpsertAcademic";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("AcademicId", academic.AcademicId);
                sqlCommand.Parameters.AddWithValue("@AcademicStartYear", academic.AcademicStartYear);
                sqlCommand.Parameters.AddWithValue("@AcademicEndYear", academic.AcademicEndYear);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();
                return academic;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteAcademic(long AcademicId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                AcademicStoreInfo academics = new AcademicStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_DeleteAcademic";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@AcademicId", AcademicId);
                sqlConnection.Open();
                var academicId = sqlCommand.ExecuteNonQuery();
                if (academicId == 1)
                {
                    return "AcademicId Deleted Sucessfully";
                }
                else
                {
                    return "AcademicId Not Found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}