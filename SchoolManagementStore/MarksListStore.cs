using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SchoolManagementStore
{
    public interface IMarksListStore
    {
        List<MarksListStoreInfo> GetMarksList(long AcademicId, string ExamType, string ClassName);
        List<MarksListSubjectWise> GetSubjectWiseMarks();
        List<MarksListSubjectWise> GetStudentRollNo(string RollNo);


    }
    public class MarksListStore : IMarksListStore
    {
        private readonly IConfiguration _iconfiguration;
        public MarksListStore(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }
        public List<MarksListStoreInfo> GetMarksList(long AcademicId, string ExamType, string ClassName)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                List<MarksListStoreInfo> students = new List<MarksListStoreInfo>();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_MarksList";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@AcademicId", AcademicId);
                sqlCommand.Parameters.AddWithValue("@ExamType", ExamType);
                sqlCommand.Parameters.AddWithValue("@ClassName", ClassName);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        students.Add(new MarksListStoreInfo
                        {
                            RollNo = sqlDataReader["RollNo"].ToString(),
                            FirstName = sqlDataReader["FirstName"].ToString(),
                            LastName = sqlDataReader["LastName"].ToString(),
                            Gender = sqlDataReader["Gender"].ToString(),
                            ClassName = sqlDataReader["ClassName"].ToString(),
                            Section = sqlDataReader["Section"].ToString(),
                            GroupName = sqlDataReader["GroupName"].ToString(),
                            ExamType = sqlDataReader["ExamType"].ToString(),
                            TotalMarks = Convert.ToInt16(sqlDataReader["TotalMarks"]),
                            RankList = Convert.ToInt16(sqlDataReader["RankList"])
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

        public List<MarksListSubjectWise> GetSubjectWiseMarks()
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                List<MarksListSubjectWise> students = new List<MarksListSubjectWise>();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_Marks";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        students.Add(new MarksListSubjectWise
                        {
                            RollNo = sqlDataReader["RollNo"].ToString(),
                            FirstName = sqlDataReader["FirstName"].ToString(),
                            LastName = sqlDataReader["LastName"].ToString(),
                            Gender = sqlDataReader["Gender"].ToString(),
                            ClassName = sqlDataReader["ClassName"].ToString(),
                            Section = sqlDataReader["Section"].ToString(),
                            GroupName = sqlDataReader["GroupName"].ToString(),
                            ExamType = sqlDataReader["ExamType"].ToString(),
                            SubjectName = sqlDataReader["SubjectName"].ToString(),
                            MarksObtained = Convert.ToInt16(sqlDataReader["MarksObtained"]),
                            TotalMarksObtained = Convert.ToInt16(sqlDataReader["TotalMarksObtained"])
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
        public List<MarksListSubjectWise> GetStudentRollNo(string RollNo)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                List<MarksListSubjectWise> students = new List<MarksListSubjectWise>();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GetMarksByRollNo";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@RollNo", RollNo);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        students.Add(new MarksListSubjectWise
                        {
                            RollNo = sqlDataReader["RollNo"].ToString(),
                            FirstName = sqlDataReader["FirstName"].ToString(),
                            LastName = sqlDataReader["LastName"].ToString(),
                            Gender = sqlDataReader["Gender"].ToString(),
                            ClassName = sqlDataReader["ClassName"].ToString(),
                            Section = sqlDataReader["Section"].ToString(),
                            GroupName = sqlDataReader["GroupName"].ToString(),
                            ExamType = sqlDataReader["ExamType"].ToString(),
                            SubjectName = sqlDataReader["SubjectName"].ToString(),
                            MarksObtained = Convert.ToInt16(sqlDataReader["MarksObtained"]),
                            TotalMarksObtained = Convert.ToInt16(sqlDataReader["TotalMarksObtained"])
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
    }
}

