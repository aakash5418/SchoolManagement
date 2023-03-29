using SchoolManagementStore;
using System.Collections;

namespace SchoolManagementService
{
    public interface IMarksService
    {
        List<MarksServiceInfo> GetMarks();
        MarksServiceInfo GetMarksId(long MarksId);
        ArrayList AddMarks(MarksServiceInfo Marks);
        ArrayList UpdateMarks(MarksServiceInfo Marks);
        string DeleteMarks(long MarksId);
    }
    public class MarksService : IMarksService
    {
        private readonly IMarksStore _marksStore;
        private readonly IAcademicStudentStore _academicStudentStore;
        private readonly IExamsStore _examsStore;
        private readonly ISubjectsStore _subjectsStore;
        public MarksService(IMarksStore marksStore, IAcademicStudentStore academicStudentStore, IExamsStore examsStore, ISubjectsStore subjectsStore)
        {
            _marksStore = marksStore;
            _academicStudentStore = academicStudentStore;
            _examsStore = examsStore;
            _subjectsStore = subjectsStore;
        }
        public List<MarksServiceInfo> GetMarks()
        {
            var markStoreInfo = _marksStore.GetMarks();
            if (markStoreInfo == null)
            {
                return null;
            }
            else
            {
                var marksList = new List<MarksServiceInfo>();
                foreach (var mark in markStoreInfo)
                {
                    marksList.Add(new MarksServiceInfo
                    {
                        MarksId = mark.MarksId,
                        MarksObtained = mark.MarksObtained,
                        TotalMarksObtained = mark.TotalMarksObtained,
                        AcademicStudentId = mark.AcademicStudentId,
                        ExamId = mark.ExamId,
                        SubjectId = mark.SubjectId,
                        CreatedDate = mark.CreatedDate,
                        ModifiedDate = mark.ModifiedDate,
                    });
                }
                return marksList;
            }
        }
        public MarksServiceInfo GetMarksId(long MarksId)
        {
            var markStoreInfo = _marksStore.GetMarksId(MarksId);
            if (markStoreInfo == null)
            {
                return null;
            }
            else
            {
                return new MarksServiceInfo
                {
                    MarksId = markStoreInfo.MarksId,
                    MarksObtained = markStoreInfo.MarksObtained,
                    TotalMarksObtained = markStoreInfo.TotalMarksObtained,
                    AcademicStudentId = markStoreInfo.AcademicStudentId,
                    ExamId = markStoreInfo.ExamId,
                    SubjectId = markStoreInfo.SubjectId,
                    CreatedDate = markStoreInfo.CreatedDate,
                    ModifiedDate = markStoreInfo.ModifiedDate,
                };
            }
        }
        public ArrayList AddMarks(MarksServiceInfo Marks)
        {
            var validMarks = ValidateMarks(Marks);
            if (validMarks.Count == 0)
            {
                var marksExists = IsMarksExists(Marks);
                if (marksExists.Count == 0)
                {
                    var marksStoreInfo = new MarksStoreInfo();
                    marksStoreInfo.MarksObtained = Marks.MarksObtained;
                    marksStoreInfo.TotalMarksObtained = Marks.TotalMarksObtained;
                    marksStoreInfo.AcademicStudentId = Marks.AcademicStudentId;
                    marksStoreInfo.ExamId = Marks.ExamId;
                    marksStoreInfo.SubjectId = Marks.SubjectId;
                    _marksStore.AddMarks(marksStoreInfo);
                }
                else
                {
                    return marksExists;
                }
            }
            else
            {
                return validMarks;
            }
            return validMarks;
        }
        public ArrayList UpdateMarks(MarksServiceInfo Marks)
        {
            var validMarks = ValidateMarks(Marks);
            if (validMarks.Count == 0)
            {
                var markStoreInfo = new MarksStoreInfo();
                markStoreInfo.MarksId = Marks.MarksId;
                markStoreInfo.MarksObtained = Marks.MarksObtained;
                markStoreInfo.TotalMarksObtained = Marks.TotalMarksObtained;
                markStoreInfo.AcademicStudentId = Marks.AcademicStudentId;
                markStoreInfo.ExamId = Marks.ExamId;
                markStoreInfo.SubjectId = Marks.SubjectId;
                _marksStore.UpdateMarks(markStoreInfo);
            }
            else
            {
                return validMarks;
            }
            return validMarks;
        }
        public string DeleteMarks(long MarksId)
        {
            try
            {
                var markList = _marksStore.DeleteMarks(MarksId);
                return markList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private ArrayList ValidateMarks(MarksServiceInfo Marks)
        {
            ArrayList validMarks = new ArrayList();

            if (Marks.MarksObtained <= 0 && Marks.MarksObtained >= 100)
            {
                validMarks.Add("MarksObtained Does Not Exists");
            }
            if (Marks.TotalMarksObtained <= 0)
            {
                validMarks.Add("TotalMarksObtained Does Not Exists");
            }
            if (Marks.AcademicStudentId <= 0)
            {
                validMarks.Add("AcademicStudentId Does Not Exists");
            }
            if (Marks.ExamId <= 0)
            {
                validMarks.Add("ExamId Does Not Exists");
            }
            if (Marks.SubjectId <= 0)
            {
                validMarks.Add("SubjectId Does Not Exists");
            }
            return validMarks;
        }
        private ArrayList IsMarksExists(MarksServiceInfo Marks)
        {
            ArrayList marksExists = new ArrayList();
            var academicStudentList = _academicStudentStore.GetAcademicStudentId(Marks.AcademicStudentId);
            if (academicStudentList == null)
            {
                marksExists.Add("AcademicStudentId Is Not Exists");
                return marksExists;
            }
            if (academicStudentList.AcademicStudentId != Marks.AcademicStudentId)
            {
                marksExists.Add("AcademicStudentId MissMatched");
                return marksExists;
            }
            var examList = _examsStore.GetExamsId(Marks.ExamId);
            if (examList == null)
            {
                marksExists.Add("ExamId Is Not Exists");
                return marksExists;
            }
            if (examList.ExamId != Marks.ExamId)
            {
                marksExists.Add("ExamId MissMatched");
                return marksExists;
            }
            var subjectList = _subjectsStore.GetSubjectsId(Marks.SubjectId);
            if (subjectList == null)
            {
                marksExists.Add("SubjectId Is Does Not Exists");
                return marksExists;
            }
            if (subjectList.SubjectId != Marks.SubjectId)
            {
                marksExists.Add("SubjectId MissMatched");
                return marksExists;
            }
            return marksExists;
        }
    }
}
