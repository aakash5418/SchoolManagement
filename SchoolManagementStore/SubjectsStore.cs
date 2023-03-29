using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SchoolManagementStore
{
    public interface ISubjectsStore
    {
        List<SubjectsStoreInfo> GetSubjects();
        SubjectsStoreInfo GetSubjectsId(long SubjectId);
        SubjectsStoreInfo AddSubjects(SubjectsStoreInfo Subjects);
        SubjectsStoreInfo UpdateSubjects(SubjectsStoreInfo Subjects);
        string DeleteSubjects(long SubjectId);
    }
    public class SubjectStore : ISubjectsStore
    {
        private readonly IConfiguration _iconfiguration;
        public SubjectStore(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }
        public List<SubjectsStoreInfo> GetSubjects()
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                List<SubjectsStoreInfo> Subjects = new List<SubjectsStoreInfo>();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GetSubjects";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        Subjects.Add(new SubjectsStoreInfo
                        {
                            SubjectId = Convert.ToInt64(sqlDataReader["SubjectId"]),
                            SubjectName = (sqlDataReader["SubjectName"].ToString()),
                            SubjectCode = (sqlDataReader["SubjectCode"].ToString()),
                            GroupId = Convert.ToInt64(sqlDataReader["GroupId"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"])
                        });
                    }
                    sqlConnection.Close();
                }
                return Subjects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public SubjectsStoreInfo GetSubjectsId(long SubjectId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SubjectsStoreInfo Subjects = new SubjectsStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GetSubjectId";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SubjectId", SubjectId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        Subjects = new SubjectsStoreInfo()
                        {
                            SubjectId = Convert.ToInt64(sqlDataReader["SubjectId"]),
                            SubjectName = (sqlDataReader["SubjectName"].ToString()),
                            SubjectCode = (sqlDataReader["SubjectCode"].ToString()),
                            GroupId = Convert.ToInt64(sqlDataReader["GroupId"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"])
                        };
                    }
                    sqlConnection.Close();
                }
                return Subjects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public SubjectsStoreInfo AddSubjects(SubjectsStoreInfo Subjects)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_AddSubjects";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SubjectName", Subjects.SubjectName);
                sqlCommand.Parameters.AddWithValue("@SubjectCode", Subjects.SubjectCode);
                sqlCommand.Parameters.AddWithValue("@GroupId", Subjects.GroupId);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();
                return Subjects;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public SubjectsStoreInfo UpdateSubjects(SubjectsStoreInfo Subjects)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_UpsertSubjects";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SubjectId", Subjects.SubjectId);
                sqlCommand.Parameters.AddWithValue("@SubjectName", Subjects.SubjectName);
                sqlCommand.Parameters.AddWithValue("@SubjectCode", Subjects.SubjectCode);
                sqlCommand.Parameters.AddWithValue("@GroupId", Subjects.GroupId);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();
                return Subjects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteSubjects(long SubjectId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                GroupsStoreInfo academics = new GroupsStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_DeleteSubjects";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SubjectId", SubjectId);
                sqlConnection.Open();
                var  subjectId = sqlCommand.ExecuteNonQuery();
                if(subjectId != 0)
                {
                    return "SubjectId Deleted Sucessfully";
                }
                else
                {
                    return "SubjectId Not Found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
