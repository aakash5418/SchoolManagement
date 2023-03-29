using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SchoolManagementStore
{
    public interface IExamsStore
    {
        List<ExamsStoreInfo> GetExams();
        ExamsStoreInfo GetExamsId(long ExamId);
        ExamsStoreInfo AddExams(ExamsStoreInfo exams);
        ExamsStoreInfo UpdateExams(ExamsStoreInfo exams);
        string DeleteExams(long ExamId);
    }

    public class ExamStore : IExamsStore
    {
        private readonly IConfiguration _iconfiguration;
        public ExamStore(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        public List<ExamsStoreInfo> GetExams()
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                List<ExamsStoreInfo> exams = new List<ExamsStoreInfo>();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_Exams";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        exams.Add(new ExamsStoreInfo
                        {
                            ExamId = Convert.ToInt64(sqlDataReader["ExamId"]),
                            ExamType = sqlDataReader["ExamType"].ToString(),
                            AcademicId = Convert.ToInt64(sqlDataReader["AcademicId"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"])
                        });
                    }
                    sqlConnection.Close();
                }
                return exams;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ExamsStoreInfo GetExamsId(long ExamId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                ExamsStoreInfo exams = new ExamsStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_ExamsId";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ExamId", ExamId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        exams = new ExamsStoreInfo()
                        {
                            ExamId = Convert.ToInt64(sqlDataReader["ExamId"]),
                            ExamType = sqlDataReader["ExamType"].ToString(),
                            AcademicId = Convert.ToInt64(sqlDataReader["AcademicId"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"])
                        };
                    }
                    sqlConnection.Close();
                }
                return exams;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ExamsStoreInfo AddExams(ExamsStoreInfo exams)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_AddExams";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("ExamType", exams.ExamType);
                sqlCommand.Parameters.AddWithValue("AcademicId", exams.AcademicId);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();
                return exams;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ExamsStoreInfo UpdateExams(ExamsStoreInfo exams)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_UpsertExams";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ExamId",exams.ExamId);
                sqlCommand.Parameters.AddWithValue("ExamType", exams.ExamType);
                sqlCommand.Parameters.AddWithValue("AcademicId", exams.AcademicId);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();
                return exams;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteExams(long ExamId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                GroupsStoreInfo academics = new GroupsStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_DeleteExams";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ExamId", ExamId);
                sqlConnection.Open();
                var examId = sqlCommand.ExecuteNonQuery();
                if(examId != 0)
                {
                    return "ExamId Deleted Sucessfully";
                }
                else
                {
                    return "ExamId Not Found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
