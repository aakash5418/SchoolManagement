using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SchoolManagementStore
{
    public interface IClassStore
    {
        List<ClassStoreInfo> GetClass();
        ClassStoreInfo GetClassId(long ClassId);
        ClassStoreInfo AddClass(ClassStoreInfo Classes);
        ClassStoreInfo UpdateClass(ClassStoreInfo Classes);
        string DeleteClass(long ClassId);
    }

    public class ClassStore : IClassStore
    {
        private readonly IConfiguration _iconfiguration;
        public ClassStore(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }
        public List<ClassStoreInfo> GetClass()
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                List<ClassStoreInfo> classes = new List<ClassStoreInfo>();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_Getclass";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        classes.Add(new ClassStoreInfo
                        {
                            ClassId = Convert.ToInt64(sqlDataReader["ClassId"]),
                            ClassName = sqlDataReader["ClassName"].ToString(),
                            Section = sqlDataReader["Section"].ToString(),
                            AcademicId = Convert.ToInt64(sqlDataReader["AcademicId"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"])
                        });
                    }
                    sqlConnection.Close();
                }
                return classes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ClassStoreInfo GetClassId(long ClassId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                ClassStoreInfo classes = new ClassStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GetClassId";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("ClassId", ClassId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        classes = new ClassStoreInfo()
                        {
                            ClassId = Convert.ToInt64(sqlDataReader["ClassId"]),
                            ClassName = sqlDataReader["ClassName"].ToString(),
                            Section = sqlDataReader["Section"].ToString(),
                            AcademicId = Convert.ToInt64(sqlDataReader["AcademicId"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"]),
                        };
                    }
                    sqlConnection.Close();
                }
                return classes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ClassStoreInfo AddClass(ClassStoreInfo Classes)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_AddClass";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@ClassName", Classes.ClassName);
                sqlCommand.Parameters.AddWithValue("@Section", Classes.Section);
                sqlCommand.Parameters.AddWithValue("@AcademicId", Classes.AcademicId);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();
                return Classes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ClassStoreInfo UpdateClass(ClassStoreInfo Classes)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_UpsertClass";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("ClassId", Classes.ClassId);
                sqlCommand.Parameters.AddWithValue("@ClassName", Classes.ClassName);
                sqlCommand.Parameters.AddWithValue("@Section", Classes.Section);
                sqlCommand.Parameters.AddWithValue("@AcademicId", Classes.AcademicId);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();
                return Classes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteClass(long ClassId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                AcademicStoreInfo academics = new AcademicStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_DeleteClass";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("ClassId", ClassId);
                sqlConnection.Open();
                var classId = sqlCommand.ExecuteNonQuery();
                if(classId != 0)
                {
                    return "ClassId Deleted SucessFully";
                }
                else
                {
                    return "ClassId Not Found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
