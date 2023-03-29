using System;

namespace SchoolManagementService
{
    public class MarksServiceInfo
    {
        public long MarksId { get; set; }
        public Int16 MarksObtained { get; set; }
        public Int16 TotalMarksObtained { get; set; }
        public long AcademicStudentId { get; set; }
        public long ExamId { get; set; }
        public long SubjectId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
