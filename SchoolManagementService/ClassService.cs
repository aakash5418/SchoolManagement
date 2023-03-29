using SchoolManagementStore;
using System.Collections;

namespace SchoolManagementService
{
    public interface IClassService
    {
        List<ClassServiceInfo> GetClass();
        ClassServiceInfo GetClassId(long ClassId);
        ArrayList AddClass(ClassServiceInfo Classes);
        ArrayList UpdateClass(ClassServiceInfo Classes);
        string DeleteClass(long ClassId);
    }

    public class ClassService : IClassService
    {
        private readonly IClassStore _classStore;
        private readonly IAcademicStore _academicStore;
        public ClassService(IClassStore classStore, IAcademicStore academicStore)
        {
            _classStore = classStore;
            _academicStore = academicStore;
        }
        public List<ClassServiceInfo> GetClass()
        {
            try
            {
                var classStoreInfo = _classStore.GetClass();
                if (classStoreInfo == null)
                {
                    return null;
                }
                else
                {
                    var classList = new List<ClassServiceInfo>();
                    foreach (var classStore in classStoreInfo)
                    {
                        classList.Add(new ClassServiceInfo
                        {
                            ClassId = classStore.ClassId,
                            ClassName = classStore.ClassName,
                            Section = classStore.Section,
                            AcademicId = classStore.AcademicId,
                            CreatedDate = classStore.CreatedDate,
                            ModifiedDate = classStore.ModifiedDate
                        });
                    }
                    return classList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ClassServiceInfo GetClassId(long ClassId)
        {
            try
            {
                var classStoreInfo = _classStore.GetClassId(ClassId);
                if (classStoreInfo == null)
                {
                    return null;
                }
                else
                {
                    return new ClassServiceInfo
                    {
                        ClassId = classStoreInfo.ClassId,
                        ClassName = classStoreInfo.ClassName,
                        Section = classStoreInfo.Section,
                        AcademicId = classStoreInfo.AcademicId,
                        CreatedDate = classStoreInfo.CreatedDate,
                        ModifiedDate = classStoreInfo.ModifiedDate
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ArrayList AddClass(ClassServiceInfo Classes)
        {
            try
            {
                var validClass = ValidateClass(Classes);
                if (validClass.Count == 0)
                {
                    var validExists = IsValidExists(Classes);
                    if (validExists.Count == 0)
                    {
                        var classStoreInfo = new ClassStoreInfo();
                        classStoreInfo.ClassName = Classes.ClassName;
                        classStoreInfo.Section = Classes.Section;
                        classStoreInfo.AcademicId = Classes.AcademicId;
                        _classStore.AddClass(classStoreInfo);
                    }
                    else
                    {
                        return validExists;
                    }
                }
                else
                {
                    return validClass;
                }
                return validClass;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ArrayList UpdateClass(ClassServiceInfo Classes)
        {
            try
            {
                var validClass = ValidateClass(Classes);
                if (validClass.Count == 0)
                {
                    var validExists = IsValidExists(Classes);
                    if (validExists.Count == 0)
                    {
                        var classStoreInfo = new ClassStoreInfo();
                        classStoreInfo.ClassId = Classes.ClassId;
                        classStoreInfo.ClassName = Classes.ClassName;
                        classStoreInfo.Section = Classes.Section;
                        classStoreInfo.AcademicId = Classes.AcademicId;
                        _classStore.UpdateClass(classStoreInfo);
                    }
                    else
                    {
                        return validExists;
                    }
                }
                else
                {
                    return validClass;
                }
                return validClass;
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
                var classList = _classStore.DeleteClass(ClassId);
                return classList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private ArrayList ValidateClass(ClassServiceInfo Classes)
        {
            ArrayList validClass = new ArrayList();
            if (string.IsNullOrEmpty(Classes.ClassName))
            {
                validClass.Add("ClassName  Does Not Exists");
            }
            if (string.IsNullOrEmpty(Classes.Section))
            {
                validClass.Add("ClassSection Does Not Exists ");
            }
            if (Classes.AcademicId <= 0)
            {
                validClass.Add("AcademicId Does Not Exists");
            }
            return validClass;
        }
        private ArrayList IsValidExists(ClassServiceInfo Classes)
        {
            ArrayList validExists = new ArrayList();
            var validAcademic = _academicStore.GetAcademicId(Classes.AcademicId);
            if (validAcademic == null)
            {
                validExists.Add("AcademicId  Not Exists");
                return validExists;
            }
            if (validAcademic.AcademicId != Classes.AcademicId)
            {
                validExists.Add("AcademicId MissMatched");
            }
            return validExists;
        }
    }
}
