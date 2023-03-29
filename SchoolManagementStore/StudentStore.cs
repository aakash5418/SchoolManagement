using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagementStore
{
    public interface IStudentStore
    {
        List<StudentStoreInfo> GetStudent();
        StudentStoreInfo GetStudentByRollNo(string RollNo);
        StudentStoreInfo GetStudentId(long StudentId);
        StudentStoreInfo AddStudent(StudentStoreInfo student);
        StudentStoreInfo UpdateStudent(StudentStoreInfo student);
        string DeleteStudent(string RollNo);
    }
    public class StudentStore : IStudentStore
    {
        private readonly IConfiguration _iconfiguration;
        public StudentStore(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        public List<StudentStoreInfo> GetStudent()
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                List<StudentStoreInfo> students = new List<StudentStoreInfo>();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GetStudent";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        students.Add(new StudentStoreInfo
                        {
                            StudentId = Convert.ToInt64(sqlDataReader["StudentId"]),
                            RollNo = sqlDataReader["RollNo"].ToString(),
                            FirstName = sqlDataReader["FirstName"].ToString(),
                            LastName = sqlDataReader["LastName"].ToString(),
                            Gender = sqlDataReader["Gender"].ToString(),
                            DateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]),
                            DateOfAdmission = Convert.ToDateTime(sqlDataReader["DateOfAdmission"]),
                            DateOfDiscontinue = (sqlDataReader.IsDBNull("DateOfDiscontinue") ? dateTimeValue : (DateTime)sqlDataReader["DateOfDiscontinue"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"]),
                        });
                    }
                    sqlConnection.Close();
                }
                return students;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public StudentStoreInfo GetStudentByRollNo(string RollNo)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                StudentStoreInfo students = new StudentStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GetStudentByRollNo";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RollNo", RollNo);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        students = new StudentStoreInfo()
                        {
                            StudentId = Convert.ToInt64(sqlDataReader["StudentId"]),
                            RollNo = sqlDataReader["RollNo"].ToString(),
                            FirstName = sqlDataReader["FirstName"].ToString(),
                            LastName = sqlDataReader["LastName"].ToString(),
                            Gender = sqlDataReader["Gender"].ToString(),
                            DateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]),
                            DateOfAdmission = Convert.ToDateTime(sqlDataReader["DateOfBirth"]),
                            DateOfDiscontinue = (sqlDataReader.IsDBNull("DateOfDiscontinue") ? dateTimeValue : (DateTime)sqlDataReader["DateOfDiscontinue"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"])
                        };
                    }
                    sqlConnection.Close();
                }
                return students;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public StudentStoreInfo GetStudentId(long StudentId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                StudentStoreInfo students = new StudentStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GetStudentId";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StudentId", StudentId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        students = new StudentStoreInfo()
                        {
                            StudentId = Convert.ToInt64(sqlDataReader["StudentId"]),
                            RollNo = sqlDataReader["RollNo"].ToString(),
                            FirstName = sqlDataReader["FirstName"].ToString(),
                            LastName = sqlDataReader["LastName"].ToString(),
                            Gender = sqlDataReader["Gender"].ToString(),
                            DateOfBirth = Convert.ToDateTime(sqlDataReader["DateOfBirth"]),
                            DateOfAdmission = Convert.ToDateTime(sqlDataReader["DateOfBirth"]),
                            DateOfDiscontinue = (sqlDataReader.IsDBNull("DateOfDiscontinue") ? dateTimeValue : (DateTime)sqlDataReader["DateOfDiscontinue"]),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"])
                        };
                    }
                    sqlConnection.Close();
                }
                return students;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public StudentStoreInfo AddStudent(StudentStoreInfo student)
        {
            try {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_AddStudent";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RollNo", student.RollNo);
                sqlCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", student.LastName);
                sqlCommand.Parameters.AddWithValue("@Gender", student.Gender);
                sqlCommand.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                sqlCommand.Parameters.AddWithValue("@DateOfAdmission", student.DateOfAdmission);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                return student;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public StudentStoreInfo UpdateStudent(StudentStoreInfo student)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_UpsertStudent";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StudentId", student.StudentId);
                sqlCommand.Parameters.AddWithValue("@RollNo", student.RollNo);
                sqlCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", student.LastName);
                sqlCommand.Parameters.AddWithValue("@Gender", student.Gender);
                sqlCommand.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
                sqlCommand.Parameters.AddWithValue("@DateOfAdmission", student.DateOfAdmission);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();

                return student;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteStudent(string RollNo)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_DeleteRollNo";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RollNo", RollNo);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                var rollNo =  sqlCommand.ExecuteNonQuery();
                if(rollNo == 1)
                {
                    return "Student RollNo Deleted Sucessfully";
                }
                else
                {
                    return "Student RollNo Not Found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
