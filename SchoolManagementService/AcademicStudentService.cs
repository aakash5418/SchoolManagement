using SchoolManagementStore;
using System.Collections;

namespace SchoolManagementService
{
    public interface IAcademicStudentService
    {
        List<AcademicStudentServiceInfo> GetAcademicStudent();
        AcademicStudentServiceInfo GetAcademicStudentId(long AcademicStudentId);
        ArrayList AddAcademicStudent(AcademicStudentServiceInfo academicStudent);
        ArrayList UpdateAcademicStudent(AcademicStudentServiceInfo academicStudent);
        string DeleteAcademicStudent(long AcademicStudentId);
    }
    public class AcademicStudentService : IAcademicStudentService
    {
        private readonly IAcademicStudentStore _academicStudentStore;
        private readonly IStudentStore _studentStore;
        private readonly IAcademicStore _academicStore;
        private readonly IClassStore _classStore;
        private readonly IGroupsStore _groupsStore;
        public AcademicStudentService(IAcademicStudentStore academicStudentStore,
                                      IStudentStore studentStore,
                                      IAcademicStore academicStore,
                                      IClassStore classStore,
                                      IGroupsStore groupsStore)
        {
            _academicStudentStore = academicStudentStore;
            _studentStore = studentStore;
            _academicStore = academicStore;
            _classStore = classStore;
            _groupsStore = groupsStore;
        }
        public List<AcademicStudentServiceInfo> GetAcademicStudent()
        {
            try
            {
                var academicStudentStore = _academicStudentStore.GetAcademicStudent();
                if (academicStudentStore == null)
                {
                    return null;
                }
                else
                {
                    var acadamicStudentList = new List<AcademicStudentServiceInfo>();
                    foreach (var storeinfo in academicStudentStore)
                    {
                        acadamicStudentList.Add(new AcademicStudentServiceInfo
                        {
                            AcademicStudentId = storeinfo.AcademicStudentId,
                            StudentId = storeinfo.StudentId,
                            AcademicId = storeinfo.AcademicId,
                            ClassId = storeinfo.ClassId,
                            GroupId = storeinfo.GroupId,
                            CreatedDate = storeinfo.CreatedDate,
                            ModifiedDate = storeinfo.ModifiedDate,
                        });
                    }
                    return acadamicStudentList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public AcademicStudentServiceInfo GetAcademicStudentId(long AcademicStudentId)
        {
            try
            {
                var academicStudentStore = _academicStudentStore.GetAcademicStudentId(AcademicStudentId);
                if (academicStudentStore == null)
                {
                    return null;
                }
                else
                {
                    return new AcademicStudentServiceInfo
                    {
                        AcademicStudentId = academicStudentStore.AcademicStudentId,
                        StudentId = academicStudentStore.StudentId,
                        AcademicId = academicStudentStore.AcademicId,
                        ClassId = academicStudentStore.ClassId,
                        GroupId = academicStudentStore.GroupId,
                        CreatedDate = academicStudentStore.CreatedDate,
                        ModifiedDate = academicStudentStore.ModifiedDate,
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ArrayList AddAcademicStudent(AcademicStudentServiceInfo academicStudent)
        {
            try
            {
                var validAcademicStudent = ValidateAcademicStudent(academicStudent);
                if (validAcademicStudent.Count == 0)
                {
                    var validExists = IsAcademicStudentExists(academicStudent);
                    if (validExists.Count == 0)
                    {
                        var acdemicStudentStore = new AcademicStudentStoreInfo();
                        acdemicStudentStore.StudentId = academicStudent.StudentId;
                        acdemicStudentStore.AcademicId = academicStudent.ClassId;
                        acdemicStudentStore.ClassId = academicStudent.ClassId;
                        acdemicStudentStore.GroupId = academicStudent.GroupId;
                        _academicStudentStore.AddAcademicStudent(acdemicStudentStore);
                    }
                    else
                    {
                        return validExists;
                    }
                }
                else
                {
                    return validAcademicStudent;
                }
                return validAcademicStudent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ArrayList UpdateAcademicStudent(AcademicStudentServiceInfo academicStudent)
        {
            try
            {
                var acdamicStudentList = ValidateAcademicStudent(academicStudent);
                if (acdamicStudentList.Count == 0)
                {
                    var validExists = IsAcademicStudentExists(academicStudent);
                    if (validExists.Count == 0)
                    {
                        var acdemicStudentStore = new AcademicStudentStoreInfo();
                        acdemicStudentStore.AcademicStudentId = academicStudent.AcademicStudentId;
                        acdemicStudentStore.StudentId = academicStudent.StudentId;
                        acdemicStudentStore.AcademicId = academicStudent.ClassId;
                        acdemicStudentStore.ClassId = academicStudent.ClassId;
                        acdemicStudentStore.GroupId = academicStudent.GroupId;
                        _academicStudentStore.UpdateAcademicStudent(acdemicStudentStore);
                    }
                    else
                    {
                        return validExists;
                    }
                }
                else
                {
                    return acdamicStudentList;
                }
                return acdamicStudentList;
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
                var academicStudentList = _academicStudentStore.DeleteAcademicStudent(AcademicStudentId);
                return (academicStudentList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private ArrayList ValidateAcademicStudent(AcademicStudentServiceInfo academicStudent)
        {
            ArrayList validAcademicStudent = new ArrayList();

            if (academicStudent.StudentId <= 0)
            {
                validAcademicStudent.Add("StudentId Does Not Exists");
            }
            if (academicStudent.AcademicId <= 0)
            {
                validAcademicStudent.Add("AcademicId Does Not Exists");
            }
            if (academicStudent.GroupId <= 0)
            {
                validAcademicStudent.Add("GroupId Does Not Exists");
            }
            return validAcademicStudent;
        }

        private ArrayList IsAcademicStudentExists(AcademicStudentServiceInfo academicStudent)
        {
            ArrayList validExists = new ArrayList();
            var studentList = _studentStore.GetStudentId(academicStudent.StudentId);
            if (studentList == null)
            {
                validExists.Add("StudentId Does Not Exists");
                return validExists;
            }
            if (studentList.StudentId != academicStudent.StudentId)
            {
                validExists.Add("StudentId MissMatched");
                return validExists;
            }

            var academicList = _academicStore.GetAcademicId(academicStudent.AcademicId);
            if (academicList == null)
            {
                validExists.Add("AcademicId Does Not Exists");
                return validExists;
            }
            if (academicList.AcademicId != academicStudent.AcademicId)
            {
                validExists.Add("AcademicId MissMatched");
                return validExists;
            }
            var classList = _classStore.GetClassId(academicStudent.ClassId);
            if (classList == null)
            {
                validExists.Add("ClassId Does Not Exists");
                return validExists;
            }
            if (classList.ClassId != academicStudent.ClassId)
            {
                validExists.Add("ClassId Missmatched");
                return validExists;
            }
            var groupList = _groupsStore.GetGroupsId(academicStudent.GroupId);
            if (groupList == null)
            {
                validExists.Add("GroupId Does Not Exists");
                return validExists;
            }
            if (groupList.GroupId != academicStudent.GroupId)
            {
                validExists.Add("GroupId MissMatched");
            }
            return validExists;
        }
    }
}
