using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SchoolManagementStore
{
    public interface IAcademicStudentStore
    {
        List<AcademicStudentStoreInfo> GetAcademicStudent();
        AcademicStudentStoreInfo GetAcademicStudentId(long AcademicStudentId);
        AcademicStudentStoreInfo AddAcademicStudent(AcademicStudentStoreInfo academicStudent);
        AcademicStudentStoreInfo UpdateAcademicStudent(AcademicStudentStoreInfo academicStudent);
        string DeleteAcademicStudent(long AcademicStudentId);
    }
    public class AcademicStudentStore : IAcademicStudentStore
    {
        private readonly IConfiguration _iconfiguration;
        public AcademicStudentStore(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }
        public List<AcademicStudentStoreInfo> GetAcademicStudent()
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                List<AcademicStudentStoreInfo> academicStudent = new List<AcademicStudentStoreInfo>();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GetAcademicStudent";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        academicStudent.Add(new AcademicStudentStoreInfo
                        {
                            AcademicStudentId = Convert.ToInt64(sqlDataReader["AcademicStudentId"]),
                            StudentId = Convert.ToInt64(sqlDataReader["StudentId"]),
                            AcademicId = Convert.ToInt64(sqlDataReader["AcademicId"]),
                            ClassId = Convert.ToInt64(sqlDataReader["ClassId"]),
                            GroupId = Convert.ToInt64(sqlDataReader["GroupId"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"])
                        });
                    }
                    sqlConnection.Close();
                }
                return academicStudent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public AcademicStudentStoreInfo GetAcademicStudentId(long AcademicStudentId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                AcademicStudentStoreInfo academicStudent = new AcademicStudentStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GetAcademicStudentId";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@AcademicStudentId", AcademicStudentId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        academicStudent = new AcademicStudentStoreInfo()
                        {
                            AcademicStudentId = Convert.ToInt64(sqlDataReader["AcademicStudentId"]),
                            StudentId = Convert.ToInt64(sqlDataReader["StudentId"]),
                            AcademicId = Convert.ToInt64(sqlDataReader["AcademicId"]),
                            ClassId = Convert.ToInt64(sqlDataReader["ClassId"]),
                            GroupId = Convert.ToInt64(sqlDataReader["GroupId"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"])
                        };
                    }
                    sqlConnection.Close();
                }
                return academicStudent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public AcademicStudentStoreInfo AddAcademicStudent(AcademicStudentStoreInfo academicStudent)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_AddAcademicStudent";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StudentId", academicStudent.StudentId);
                sqlCommand.Parameters.AddWithValue("@AcademicId", academicStudent.AcademicId);
                sqlCommand.Parameters.AddWithValue("@ClassId", academicStudent.ClassId);
                sqlCommand.Parameters.AddWithValue("@GroupId", academicStudent.GroupId);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();
                return academicStudent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public AcademicStudentStoreInfo UpdateAcademicStudent(AcademicStudentStoreInfo academicStudent)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_UpsertAcademicStudent";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@AcademicStudentId", academicStudent.AcademicStudentId);
                sqlCommand.Parameters.AddWithValue("@StudentId", academicStudent.StudentId);
                sqlCommand.Parameters.AddWithValue("@AcademicId", academicStudent.AcademicId);
                sqlCommand.Parameters.AddWithValue("@ClassId", academicStudent.ClassId);
                sqlCommand.Parameters.AddWithValue("@GroupId", academicStudent.GroupId);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();
                return academicStudent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteAcademicStudent(long AcademicStudentId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                AcademicStudentStoreInfo academics = new AcademicStudentStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_DeleteAcademicStudent";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@AcademicStudentId", AcademicStudentId);
                sqlConnection.Open();
                var academicStudentId = sqlCommand.ExecuteNonQuery();
                if (academicStudentId != 0)
                {
                    return "AcademicStudentId Deleted Sucessfully";
                }
                else
                {
                    return "AcademicStudentId Not Found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
