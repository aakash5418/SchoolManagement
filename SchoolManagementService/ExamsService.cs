using SchoolManagementStore;
using System.Collections;

namespace SchoolManagementService
{
    public interface IExamsService
    {
        List<ExamsServiceInfo> GetExams();
        ExamsServiceInfo GetExamsId(long ExamId);
        ArrayList AddExams(ExamsServiceInfo exams);
        ArrayList UpdateExams(ExamsServiceInfo exams);
        string DeleteExams(long ExamId);
    }
    public class ExamService : IExamsService
    {
        private readonly IExamsStore _examStore;
        private readonly IAcademicStore _academicStore;
        public ExamService(IExamsStore examStore, IAcademicStore academicStore)
        {
            _examStore = examStore;
            _academicStore = academicStore;
        }
        public List<ExamsServiceInfo> GetExams()
        {
            try
            {
                var examStoreInfo = _examStore.GetExams();
                if (examStoreInfo == null)
                {
                    return null;
                }
                else
                {
                    var examList = new List<ExamsServiceInfo>();
                    foreach (var exam in examStoreInfo)
                    {
                        examList.Add(new ExamsServiceInfo
                        {
                            ExamId = exam.ExamId,
                            ExamType = exam.ExamType,
                            AcademicId = exam.AcademicId,
                            CreatedDate = exam.CreatedDate,
                            ModifiedDate = exam.ModifiedDate,
                        });
                    }
                    return examList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ExamsServiceInfo GetExamsId(long ExamId)
        {
            try
            {
                var examStoreInfo = _examStore.GetExamsId(ExamId);
                if (examStoreInfo == null)
                {
                    return null;
                }
                else
                {
                    return new ExamsServiceInfo
                    {
                        ExamId = examStoreInfo.ExamId,
                        ExamType = examStoreInfo.ExamType,
                        AcademicId = examStoreInfo.AcademicId,
                        CreatedDate = examStoreInfo.CreatedDate,
                        ModifiedDate = examStoreInfo.ModifiedDate,
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ArrayList AddExams(ExamsServiceInfo exams)
        {
            try
            {
                var validExams = ValidateExam(exams);
                if (validExams.Count == 0)
                {
                    var validExists = IsExamExists(exams);
                    if (validExists.Count == 0)
                    {
                        var examStoreInfo = new ExamsStoreInfo();
                        examStoreInfo.ExamId = exams.ExamId;
                        examStoreInfo.ExamType = exams.ExamType;
                        examStoreInfo.AcademicId = exams.AcademicId;
                        _examStore.AddExams(examStoreInfo);
                    }
                    else
                    {
                        return validExists;
                    }
                }
                else
                {
                    return validExams;
                }
                return validExams;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ArrayList UpdateExams(ExamsServiceInfo exams)
        {
            try
            {
                var validExams = ValidateExam(exams);
                if (validExams.Count == 0)
                {
                    var validExists = IsExamExists(exams);
                    if (validExists.Count == 0)
                    {
                        var examStoreInfo = new ExamsStoreInfo();
                        examStoreInfo.ExamId = exams.ExamId;
                        examStoreInfo.ExamType = exams.ExamType;
                        examStoreInfo.AcademicId = exams.AcademicId;
                        _examStore.UpdateExams(examStoreInfo);
                    }
                    else
                    {
                        return validExists;
                    }
                }
                else
                {
                    return validExams;
                }
                return validExams;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteExams(long ExamId)
        {
            try
            {
                var examList = _examStore.DeleteExams(ExamId);
                return examList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private ArrayList ValidateExam(ExamsServiceInfo exams)
        {
            ArrayList validExams = new ArrayList();
            if (string.IsNullOrEmpty(exams.ExamType))
            {
                validExams.Add("ExamType Does Not Exists");
            }
            if (exams.AcademicId <= 0)
            {
                validExams.Add("AcademicId Does Not Exists");
            }
            return validExams;
        }
        private ArrayList IsExamExists(ExamsServiceInfo exams)
        {
            ArrayList validExists = new ArrayList();
            var examExists = _academicStore.GetAcademicId(exams.AcademicId);
            if (examExists == null)
            {
                validExists.Add("ExamId Does Not Exists");
                return validExists;
            }
            if (examExists.AcademicId != exams.AcademicId)
            {
                validExists.Add("AcademicId Mismatched");
            }
            return validExists;
        }
    }
}



