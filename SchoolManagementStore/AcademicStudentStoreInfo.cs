
namespace SchoolManagementStore
{
    public class AcademicStudentStoreInfo
    {
        public long AcademicStudentId { get; set; }
        public long StudentId { get; set; }
        public long AcademicId { get; set; }
        public long ClassId { get; set; }
        public long GroupId { get; set; }
        public Int16 IsPassed { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
