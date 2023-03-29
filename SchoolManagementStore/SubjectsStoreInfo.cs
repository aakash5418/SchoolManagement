
namespace SchoolManagementStore
{
    public class SubjectsStoreInfo
    {
        public long SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public long GroupId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
