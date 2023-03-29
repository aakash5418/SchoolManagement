using SchoolManagementStore;
using System.Collections;

namespace SchoolManagementService
{
    public interface IGroupsService
    {
        List<GroupsServiceInfo> GetGroups();
        GroupsServiceInfo GetGroupsId(long groupId);
        ArrayList AddGroups(GroupsServiceInfo groups);
        ArrayList UpdateGroups(GroupsServiceInfo groups);
        string DeleteGroups(long GroupId);
    }
    public class GroupService : IGroupsService
    {
        private readonly IGroupsStore _groupStore;
        public GroupService(IGroupsStore groupStore)
        {
            _groupStore = groupStore;
        }
        public List<GroupsServiceInfo> GetGroups()
        {
            try
            {
                var groupStoreInfo = _groupStore.GetGroups();
                if (groupStoreInfo == null)
                {
                    return null;
                }
                else
                {
                    var groupList = new List<GroupsServiceInfo>();
                    foreach (var groups in groupStoreInfo)
                    {
                        groupList.Add(new GroupsServiceInfo
                        {
                            GroupId = groups.GroupId,
                            GroupName = groups.GroupName,
                            CreatedDate = groups.CreatedDate,
                            ModifiedDate = groups.ModifiedDate
                        });
                    }
                    return groupList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public GroupsServiceInfo GetGroupsId(long GroupId)
        {
            try
            {
                var groupStoreInfo = _groupStore.GetGroupsId(GroupId);
                if (groupStoreInfo == null)
                {
                    return null;
                }
                else
                {
                    return new GroupsServiceInfo()
                    {
                        GroupId = groupStoreInfo.GroupId,
                        GroupName = groupStoreInfo.GroupName,
                        CreatedDate = groupStoreInfo.CreatedDate,
                        ModifiedDate = groupStoreInfo.ModifiedDate
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ArrayList AddGroups(GroupsServiceInfo groups)
        {
            try
            {
                var validGroups = ValidateGroups(groups);
                if (validGroups.Count == 0)
                {
                    var validExist = IsGroupExists(groups.GroupName);
                    if (validExist.Count == 0)
                    {
                        var groupStoreInfo = new GroupsStoreInfo();
                        groupStoreInfo.GroupName = groups.GroupName;
                        _groupStore.AddGroups(groupStoreInfo);
                    }
                    else
                    {
                        return validExist;
                    }
                }
                else
                {
                    return validGroups;
                }
                return validGroups;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ArrayList UpdateGroups(GroupsServiceInfo groups)
        {
            try
            {
                var validGroups = ValidateGroups(groups);
                if (validGroups.Count == 0)
                {
                    var validExist = IsGroupExists(groups.GroupName);
                    if (validExist.Count == 0)
                    {
                        var groupStoreInfo = new GroupsStoreInfo();
                        groupStoreInfo.GroupId = groups.GroupId;
                        groupStoreInfo.GroupName = groups.GroupName;
                        _groupStore.UpdateGroups(groupStoreInfo);
                    }
                    else
                    {
                        return validExist;
                    }
                }
                else
                {
                    return validGroups;
                }
                return validGroups;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteGroups(long groupId)
        {
            try
            {
                var groupList = _groupStore.DeleteGroups(groupId);
                return groupList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private ArrayList ValidateGroups(GroupsServiceInfo groups)
        {
            ArrayList validGroups = new ArrayList();

            if (string.IsNullOrEmpty(groups.GroupName))
            {
                validGroups.Add("GroupName Does Not Exists");
            }
            return validGroups;
        }
        private ArrayList IsGroupExists(string groupName)
        {
            ArrayList validExist = new ArrayList();

            var groupExists = _groupStore.GetGroups();
            var validGroups = groupExists.Any(g => g.GroupName == groupName);
            if (validGroups)
            {
                validExist.Add("GroupName Already Exists");
            }
            return validExist;
        }
    }
}
