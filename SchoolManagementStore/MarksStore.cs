using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SchoolManagementStore
{
    public interface IMarksStore
    {
        List<MarksStoreInfo> GetMarks();
        MarksStoreInfo GetMarksId(long MarksId);
        MarksStoreInfo AddMarks(MarksStoreInfo Marks);
        MarksStoreInfo UpdateMarks(MarksStoreInfo Marks);
        string DeleteMarks(long MarksId);
    }

    public class MarksStore : IMarksStore
    {
        private readonly IConfiguration _iconfiguration;
        public MarksStore(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        public List<MarksStoreInfo> GetMarks()
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                List<MarksStoreInfo> Marks = new List<MarksStoreInfo>();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GetMarks";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        Marks.Add(new MarksStoreInfo
                        {
                            MarksId = Convert.ToInt64(sqlDataReader["MarksId"]),
                            MarksObtained = Convert.ToInt16(sqlDataReader["MarksObtained"]),
                            TotalMarksObtained = Convert.ToInt16(sqlDataReader["TotalMarksObtained"]),
                            AcademicStudentId = Convert.ToInt64(sqlDataReader["AcademicStudentId"]),
                            ExamId = Convert.ToInt64(sqlDataReader["ExamId"]),
                            SubjectId = Convert.ToInt64(sqlDataReader["SubjectId"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"])
                        });
                    }
                    sqlConnection.Close();
                }
                return Marks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public MarksStoreInfo GetMarksId(long MarksId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                MarksStoreInfo Marks = new MarksStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GetMarksId";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MarksId", MarksId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        Marks = new MarksStoreInfo()
                        {

                            MarksId = Convert.ToInt64(sqlDataReader["MarksId"]),
                            MarksObtained = Convert.ToInt16(sqlDataReader["MarksObtained"]),
                            TotalMarksObtained = Convert.ToInt16(sqlDataReader["TotalMarksObtained"]),
                            AcademicStudentId = Convert.ToInt64(sqlDataReader["AcademicStudentId"]),
                            ExamId = Convert.ToInt64(sqlDataReader["ExamId"]),
                            SubjectId = Convert.ToInt64(sqlDataReader["SubjectId"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"])                        };
                    }
                    sqlConnection.Close();
                }
                return Marks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public MarksStoreInfo AddMarks(MarksStoreInfo Marks)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_AddMarks";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MarksObtained", Marks.MarksObtained);
                sqlCommand.Parameters.AddWithValue("@TotalMarksObtained", Marks.TotalMarksObtained);
                sqlCommand.Parameters.AddWithValue("@AcademicStudentId", Marks.AcademicStudentId);
                sqlCommand.Parameters.AddWithValue("@ExamId", Marks.ExamId);
                sqlCommand.Parameters.AddWithValue("@SubjectId", Marks.SubjectId);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();
                return Marks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public MarksStoreInfo UpdateMarks(MarksStoreInfo Marks)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_UpsertMarks";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MarksId", Marks.MarksId);
                sqlCommand.Parameters.AddWithValue("@MarksObtained", Marks.MarksObtained);
                sqlCommand.Parameters.AddWithValue("@TotalMarksObtained", Marks.TotalMarksObtained);
                sqlCommand.Parameters.AddWithValue("@AcademicStudentId", Marks.AcademicStudentId);
                sqlCommand.Parameters.AddWithValue("@ExamId", Marks.ExamId);
                sqlCommand.Parameters.AddWithValue("@SubjectId", Marks.SubjectId);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();
                return Marks;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteMarks(long MarksId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                GroupsStoreInfo academics = new GroupsStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_DeleteMarks";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MarksId", MarksId);
                sqlConnection.Open();
                var markId = sqlCommand.ExecuteNonQuery();
                if(markId != 0)
                {
                    return "MarksId Deleted Sucessfully";
                }
                else
                {
                    return "MarksId Not Found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
