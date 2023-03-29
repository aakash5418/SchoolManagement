using SchoolManagementStore;
using System.Collections;

namespace SchoolManagementService
{
    public interface ISubjectsService
    {
        List<SubjectsServiceInfo> GetSubjects();
        SubjectsServiceInfo GetSubjectsId(long SubjectId);
        ArrayList AddSubjects(SubjectsServiceInfo Subjects);
        ArrayList UpdateSubjects(SubjectsServiceInfo Subjects);
        string DeleteSubjects(long SubjectId);
    }
    public class SubjectService : ISubjectsService
    {
        private readonly ISubjectsStore _subjectsStore;
        private readonly IGroupsStore _groupStore;
        public SubjectService(ISubjectsStore subjectsStore, IGroupsStore groupStore)
        {
            _subjectsStore = subjectsStore;
            _groupStore = groupStore;
        }
        public List<SubjectsServiceInfo> GetSubjects()
        {
            var subjectStoreInfo = _subjectsStore.GetSubjects();
            if (subjectStoreInfo == null)
            {
                return null;
            }
            else
            {
                var subjectList = new List<SubjectsServiceInfo>();
                foreach (var subjects in subjectStoreInfo)
                {
                    subjectList.Add(new SubjectsServiceInfo
                    {
                        SubjectId = subjects.SubjectId,
                        SubjectName = subjects.SubjectName,
                        SubjectCode = subjects.SubjectCode,
                        GroupId = subjects.GroupId,
                        CreatedDate = subjects.CreatedDate,
                        ModifiedDate = subjects.ModifiedDate,
                    });
                }
                return subjectList;
            }
        }
        public SubjectsServiceInfo GetSubjectsId(long SubjectId)
        {
            var subjectStoreInfo = _subjectsStore.GetSubjectsId(SubjectId);
            if (subjectStoreInfo == null)
            {
                return null;
            }
            else
            {
                return new SubjectsServiceInfo
                {
                    SubjectId = subjectStoreInfo.SubjectId,
                    SubjectName = subjectStoreInfo.SubjectName,
                    SubjectCode = subjectStoreInfo.SubjectCode,
                    GroupId = subjectStoreInfo.GroupId,
                    CreatedDate = subjectStoreInfo.CreatedDate,
                    ModifiedDate = subjectStoreInfo.ModifiedDate,
                };
            }
        }
        public ArrayList AddSubjects(SubjectsServiceInfo Subjects)
        {
            try
            {
                var validSubjects = ValidateSubjects(Subjects);
                if (validSubjects.Count == 0)
                {
                    var subjectExists = IsSubjectsExists(Subjects);
                    if (subjectExists.Count == 0)
                    {
                        var subjectStoreInfo = new SubjectsStoreInfo();
                        subjectStoreInfo.SubjectName = Subjects.SubjectName;
                        subjectStoreInfo.SubjectCode = Subjects.SubjectCode;
                        subjectStoreInfo.GroupId = Subjects.GroupId;
                        _subjectsStore.AddSubjects(subjectStoreInfo);
                    }
                    else
                    {
                        return subjectExists;
                    }
                }
                else
                {
                    return validSubjects;
                }
                return validSubjects;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ArrayList UpdateSubjects(SubjectsServiceInfo Subjects)
        {
            try
            {
                var validSubjects = ValidateSubjects(Subjects);
                if (validSubjects.Count == 0)
                {
                    var subjectStoreInfo = new SubjectsStoreInfo();
                    subjectStoreInfo.SubjectId = Subjects.SubjectId;
                    subjectStoreInfo.SubjectName = Subjects.SubjectName;
                    subjectStoreInfo.SubjectCode = Subjects.SubjectCode;
                    subjectStoreInfo.GroupId = Subjects.GroupId;
                    _subjectsStore.UpdateSubjects(subjectStoreInfo);
                }
                else
                {
                    return validSubjects;
                }
                return validSubjects;
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
                var deleteList = _subjectsStore.DeleteSubjects(SubjectId);
                return deleteList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private ArrayList ValidateSubjects(SubjectsServiceInfo Subjects)
        {
            ArrayList validSubjects = new ArrayList();

            if (string.IsNullOrEmpty(Subjects.SubjectName))
            {
                validSubjects.Add("SubjectName Does Not Exists");
            }
            if (string.IsNullOrEmpty(Subjects.SubjectCode))
            {
                validSubjects.Add("SubjectCode Does Not Exists");
            }
            if (Subjects.GroupId <= 0)
            {
                validSubjects.Add("GroupId Does Not Exists");
            }
            return validSubjects;
        }
        private ArrayList IsSubjectsExists(SubjectsServiceInfo subjects)
        {
            ArrayList subjectExists = new ArrayList();
            var subjectList = _groupStore.GetGroupsId(subjects.GroupId);
            if (subjectList == null)
            {
                subjectExists.Add("SubjectID Does Not Exists");
                return subjectExists;
            }
            if (subjectList.GroupId != subjects.GroupId)
            {
                subjectExists.Add("GroupId MissMatched");
            }
            return subjectExists;
        }
    }
}
