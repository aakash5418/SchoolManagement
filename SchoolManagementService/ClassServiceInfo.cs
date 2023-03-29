
namespace SchoolManagementService
{
    public class ClassServiceInfo
    {
        public long ClassId { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public long AcademicId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
