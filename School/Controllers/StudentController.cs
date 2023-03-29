using Microsoft.AspNetCore.Mvc;
using School.Models;
using SchoolManagementService;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetStudent")]
        public IActionResult GetStudent()
        {
            try
            {
                var studentList = _studentService.GetStudent();
                return Ok(studentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetStudentByRollNo")]
        public async Task<IActionResult> GetStudentByRollNo(string RollNo)
        {
            try
            {
                var studentList = _studentService.GetStudentByRollNo(RollNo);
                return Ok(studentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetStudentId")]
        public async Task<IActionResult> GetStudentId(long StudentId)
        {
            try
            {
                var studentList = _studentService.GetStudentId(StudentId);
                return Ok(studentList);
            }
            catch (Exception ex)
            {
                return Ok(new { msg = "StudentId Not Exists" });
                 
            }
        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<IActionResult> AddStudent(StudentModel student)
        {
            try
            {
                var StudentServiceInfo = new StudentServiceInfo();
                StudentServiceInfo.RollNo = student.RollNo;
                StudentServiceInfo.FirstName = student.FirstName;
                StudentServiceInfo.LastName = student.LastName;
                StudentServiceInfo.Gender = student.Gender;
                StudentServiceInfo.DateOfBirth = student.DateOfBirth;
                StudentServiceInfo.DateOfAdmission = student.DateOfAdmission;
                var studentList = _studentService.AddStudent(StudentServiceInfo);
                return Ok(studentList);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(StudentModel student)
        {
            try
            {
                var studentServiceInfo = new StudentServiceInfo();
                studentServiceInfo.StudentId = student.StudentId;
                studentServiceInfo.RollNo = student.RollNo;
                studentServiceInfo.FirstName = student.FirstName;
                studentServiceInfo.LastName = student.LastName;
                studentServiceInfo.Gender= student.Gender;
                studentServiceInfo.DateOfBirth = student.DateOfBirth;
                studentServiceInfo.DateOfAdmission = student.DateOfAdmission;
                var studentList = _studentService.UpdateStudent(studentServiceInfo);
                return Ok(studentList);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(string RollNo)
        {
            try
            {
              var studentList =  _studentService.DeleteStudent(RollNo);
                return Ok(studentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
