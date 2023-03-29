
namespace SchoolManagementStore
{
    public class StudentStoreInfo
    {
        public long StudentId { get; set; }
        public string RollNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public DateTime? DateOfDiscontinue { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}