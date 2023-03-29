using SchoolManagementStore;

namespace SchoolManagementService
{
    public interface IMarksListService
    {
        List<MarksListServiceInfo> GetMarksList(long AcademicId, string ExamType, string ClassName);
        List<MarksListSubjectWise> GetSubjectWiseMarks();
       List<MarksListSubjectWise> GetStudentRollNo(string RollNo);
    }
    public class MarksListService : IMarksListService
    {
        private readonly IMarksListStore _marksListStore;
        public MarksListService(IMarksListStore marksListStore)
        {
            _marksListStore = marksListStore;
        }
        public List<MarksListServiceInfo> GetMarksList(long AcademicId, string ExamType, string ClassName)
        {
            try
            {   
              var marksListStoreInfo = _marksListStore.GetMarksList(AcademicId, ExamType, ClassName);
                if(marksListStoreInfo == null)
                {
                    return null;
                }
                else
                {
                    var marksList = new List<MarksListServiceInfo>();
                    foreach(var mark in marksListStoreInfo)
                    {
                        marksList.Add(new MarksListServiceInfo
                        {
                            RollNo= mark.RollNo,
                            FirstName= mark.FirstName,
                            LastName = mark.LastName,
                            Gender= mark.Gender,
                            ClassName= mark.ClassName,
                            Section= mark.Section,
                            GroupName= mark.GroupName,
                            ExamType= mark.ExamType,
                            TotalMarks = mark.TotalMarks,
                            RankList= mark.RankList,
                        });
                    }
                    return marksList;
                }
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
                var subjectStoreInfo = _marksListStore.GetSubjectWiseMarks();
                if(subjectStoreInfo == null)
                {
                    return null;
                }
                else
                {
                    var subjectMarkList = new List<MarksListSubjectWise>();
                    foreach (var mark in subjectStoreInfo)
                    {
                        subjectMarkList.Add(new MarksListSubjectWise
                        {
                           RollNo= mark.RollNo,
                           FirstName= mark.FirstName,
                           LastName = mark.LastName,
                           Gender= mark.Gender,
                           ClassName= mark.ClassName,
                           Section= mark.Section,
                           GroupName= mark.GroupName,
                           ExamType= mark.ExamType,
                           SubjectName= mark.SubjectName,
                           MarksObtained = mark.MarksObtained,
                           TotalMarksObtained= mark.TotalMarksObtained
                        });
                    }
                    return subjectMarkList;
                }
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
                var subjectStoreInfo = _marksListStore.GetStudentRollNo(RollNo);
                if (subjectStoreInfo == null)
                {
                    return null;
                }
                else
                {
                    var marksList = new List<MarksListSubjectWise>();
                    foreach(var mark in subjectStoreInfo)
                    {
                        marksList.Add(new MarksListSubjectWise
                        {
                            RollNo = mark.RollNo,
                            FirstName = mark.FirstName,
                            LastName = mark.LastName,
                            Gender = mark.Gender,
                            ClassName = mark.ClassName,
                            Section = mark.Section,
                            GroupName = mark.GroupName,
                            ExamType = mark.ExamType,
                            SubjectName = mark.SubjectName,
                            MarksObtained = mark.MarksObtained,
                            TotalMarksObtained= mark.TotalMarksObtained
                        });
                    }
                    return marksList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
