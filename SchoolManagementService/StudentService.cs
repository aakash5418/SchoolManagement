using SchoolManagementStore;
using System.Collections;

namespace SchoolManagementService
{
    public interface IStudentService
    {
        List<StudentServiceInfo> GetStudent();
        StudentServiceInfo GetStudentByRollNo(string RollNo);
        StudentServiceInfo GetStudentId(long StudentId);
        ArrayList AddStudent(StudentServiceInfo student);
        ArrayList UpdateStudent(StudentServiceInfo student);
        string DeleteStudent(string RollNo);
    }
    public class StudentService : IStudentService
    {
        private readonly IStudentStore _studentStore;
        public StudentService(IStudentStore studentStore)
        {
            _studentStore = studentStore;
        }
        public List<StudentServiceInfo> GetStudent()
        {
            try
            {
                var studentStoreInfo = _studentStore.GetStudent();
                if (studentStoreInfo != null)
                {
                    return null;
                }
                else
                {
                    var studentList = new List<StudentServiceInfo>();
                    foreach (var student in studentStoreInfo)
                    {
                        studentList.Add(new StudentServiceInfo
                        {
                            StudentId = student.StudentId,
                            RollNo = student.RollNo,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            Gender = student.Gender,
                            DateOfBirth = student.DateOfBirth,
                            DateOfAdmission = student.DateOfAdmission,
                            DateOfDiscontinue = student.DateOfDiscontinue,
                            CreatedDate = student.CreatedDate,
                            ModifiedDate = student.ModifiedDate
                        });
                    }
                    return studentList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public StudentServiceInfo GetStudentByRollNo(string RollNo)
        {
            try
            {
                var studentStoreInfo = _studentStore.GetStudentByRollNo(RollNo);
                if (studentStoreInfo == null)
                {
                    return null;
                }
                else
                {
                    return new StudentServiceInfo
                    {
                        StudentId = studentStoreInfo.StudentId,
                        RollNo = studentStoreInfo.RollNo,
                        FirstName = studentStoreInfo.FirstName,
                        LastName = studentStoreInfo.LastName,
                        Gender = studentStoreInfo.Gender,
                        DateOfBirth = studentStoreInfo.DateOfBirth,
                        DateOfAdmission = studentStoreInfo.DateOfAdmission,
                        DateOfDiscontinue = studentStoreInfo.DateOfDiscontinue,
                        CreatedDate = studentStoreInfo.CreatedDate,
                        ModifiedDate = studentStoreInfo.ModifiedDate
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public StudentServiceInfo GetStudentId(long StudentId)
        {
            try
            {
                var studentStoreInfo = _studentStore.GetStudentId(StudentId);
                if (studentStoreInfo == null)
                {
                    return null;
                }
                else
                {
                    return new StudentServiceInfo
                    {
                        StudentId = studentStoreInfo.StudentId,
                        RollNo = studentStoreInfo.RollNo,
                        FirstName = studentStoreInfo.FirstName,
                        LastName = studentStoreInfo.LastName,
                        Gender = studentStoreInfo.Gender,
                        DateOfBirth = studentStoreInfo.DateOfBirth,
                        DateOfAdmission = studentStoreInfo.DateOfAdmission,
                        DateOfDiscontinue = studentStoreInfo.DateOfDiscontinue,
                        CreatedDate = studentStoreInfo.CreatedDate,
                        ModifiedDate = studentStoreInfo.ModifiedDate
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ArrayList AddStudent(StudentServiceInfo student)
        {
            try
            {
                var validStudent = ValidateStudent(student);
                if (validStudent.Count == 0)
                {
                    var studentExists = IsStudentExist(student.RollNo);
                    if (studentExists.Count == 0)
                    {
                        var studentStoreInfo = new StudentStoreInfo();
                        studentStoreInfo.RollNo = student.RollNo;
                        studentStoreInfo.FirstName = student.FirstName;
                        studentStoreInfo.LastName = student.LastName;
                        studentStoreInfo.Gender = student.Gender;
                        studentStoreInfo.DateOfBirth = student.DateOfBirth;
                        studentStoreInfo.DateOfAdmission = DateTime.UtcNow;
                        _studentStore.AddStudent(studentStoreInfo);
                    }
                    else
                    {
                        return studentExists;
                    }
                }
                else
                {
                    return validStudent;
                }
                return validStudent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ArrayList UpdateStudent(StudentServiceInfo student)
        {
            try
            {
                var validStudent = ValidateStudent(student);
                if (validStudent.Count == 0)
                {
                    var validExists = IsStudentExist(student.RollNo);
                    if (validExists.Count == 0)
                    {
                        var studentStoreInfo = new StudentStoreInfo();
                        studentStoreInfo.StudentId = student.StudentId;
                        studentStoreInfo.RollNo = student.RollNo;
                        studentStoreInfo.FirstName = student.FirstName;
                        studentStoreInfo.LastName = student.LastName;
                        studentStoreInfo.Gender = student.Gender;
                        studentStoreInfo.DateOfBirth = student.DateOfBirth;
                        studentStoreInfo.DateOfAdmission = student.DateOfAdmission;
                        _studentStore.UpdateStudent(studentStoreInfo);
                    }
                    else
                    {
                        return validExists;
                    }
                }
                else
                {
                    return validStudent;
                }
                return validStudent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteStudent(string RollNo)
        {
            try
            {
                var deleteList = _studentStore.DeleteStudent(RollNo);
                return deleteList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private ArrayList ValidateStudent(StudentServiceInfo student)
        {
            ArrayList validStudent = new ArrayList();

            if (string.IsNullOrEmpty(student.RollNo))
            {
                validStudent.Add("RollNo Does Not Exists");
            }
            if (string.IsNullOrEmpty(student.FirstName))
            {
                validStudent.Add("Firstname Does not exists");
            }
            if (string.IsNullOrEmpty(student.LastName))
            {
                validStudent.Add("Lastname Does not exists");
            }
            if (string.IsNullOrEmpty(student.Gender))
            {
                validStudent.Add("Gender Does Not Exists");
            }
            return validStudent;
        }
        private ArrayList IsStudentExist(string RollNo)
        {
            ArrayList existStudents = new ArrayList();
            var student = _studentStore.GetStudent();
            var validStudent = student.Any(s => RollNo.Contains(s.RollNo));
            if (validStudent)
            {
                existStudents.Add("RollNo Already Exists");
            }
            return existStudents;
        }
    }
}
