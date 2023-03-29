using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SchoolManagementStore
{
    public interface IGroupsStore
    {
        List<GroupsStoreInfo> GetGroups();
        GroupsStoreInfo GetGroupsId(long GroupId);
        GroupsStoreInfo AddGroups(GroupsStoreInfo groups);
        GroupsStoreInfo UpdateGroups(GroupsStoreInfo groups);
        string DeleteGroups(long GroupId);
    }

    public class GroupStore : IGroupsStore
    {
        private readonly IConfiguration _iconfiguration;
        public GroupStore(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }
        public List<GroupsStoreInfo> GetGroups()
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                List<GroupsStoreInfo> groups = new List<GroupsStoreInfo>();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_Groups";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        groups.Add(new GroupsStoreInfo
                        {
                            GroupId = Convert.ToInt64(sqlDataReader["GroupId"]),
                            GroupName = (sqlDataReader["GroupName"].ToString()),
                            CreatedDate = Convert.ToDateTime(sqlDataReader["CreatedDate"]),
                            ModifiedDate = (sqlDataReader.IsDBNull("ModifiedDate") ? dateTimeValue : (DateTime)sqlDataReader["ModifiedDate"]),
                        });
                    }
                    sqlConnection.Close();
                }
                return groups;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public GroupsStoreInfo GetGroupsId(long groupId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                GroupsStoreInfo academics = new GroupsStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_GroupsId";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@GroupId", groupId);
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                {
                    while (sqlDataReader.Read())
                    {
                        DateTime? dateTimeValue = null;
                        academics = new GroupsStoreInfo()
                        {
                            GroupId = Convert.ToInt64(sqlDataReader["GroupId"]),
                            GroupName = (sqlDataReader["GroupName"].ToString()),
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
        public GroupsStoreInfo AddGroups(GroupsStoreInfo groups)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_AddGroups";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@GroupName", groups.GroupName);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();
                return groups;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public GroupsStoreInfo UpdateGroups(GroupsStoreInfo groups)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string query = "sp_Upsertgroups";
                SqlCommand sqlCommand = new SqlCommand(query);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@GroupId", groups.GroupId);
                sqlCommand.Parameters.AddWithValue("@GroupName", groups.GroupName);
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                sqlConnection.Close();
                return groups;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteGroups(long GroupId)
        {
            try
            {
                string Connection = _iconfiguration.GetConnectionString("StudentDb");
                GroupsStoreInfo academics = new GroupsStoreInfo();
                SqlConnection sqlConnection = new SqlConnection(Connection);
                string Query = "sp_DeleteGroups";
                SqlCommand sqlCommand = new SqlCommand(Query);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@GroupId", GroupId);
                sqlConnection.Open();
                var groupId = sqlCommand.ExecuteNonQuery();
                if (groupId != 0)
                {
                    return "GroupId Deleted SucessFully";
                }
                else
                {
                    return "GroupId Not Found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
