
namespace SchoolManagementService
{
    public class MarksListServiceInfo
    {
        public string RollNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public string GroupName { get; set; }
        public string ExamType { get; set; }
        public int TotalMarks { get; set; }
        public int RankList { get; set; }
    }
    public class MarksListSubjectWise
    {
        public string RollNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public string GroupName { get; set; }
        public string ExamType { get; set; }
        public string SubjectName { get; set; }
        public int MarksObtained { get; set; }
        public int TotalMarksObtained { get; set; }
    }
}
