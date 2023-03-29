using Microsoft.AspNetCore.Mvc;
using School.Models;
using SchoolManagementService;
namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicStudentController : ControllerBase
    {
        private readonly IAcademicStudentService _academicStudentService;
        public AcademicStudentController(IAcademicStudentService academicStudentService)
        {
            _academicStudentService = academicStudentService;
        }

        [HttpGet]
        [Route("GetAcademicStudent")]
        public IActionResult GetAcademicStudent()
        {
            try
            {
                var academicStudentList = _academicStudentService.GetAcademicStudent();
                return Ok(academicStudentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAcademicStudentId")]
        public async Task<IActionResult> GetAcademicStudentId(long AcademicStudentId)
        {
            try
            {
                var academicStudentList = _academicStudentService.GetAcademicStudentId(AcademicStudentId);
                return Ok(academicStudentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddAcademicStudent")]
        public async Task<IActionResult> AddAcademicStudent(AcademicStudentModel academicStudent)
        {
            try
            {
                var academicStudentServiceInfo = new AcademicStudentServiceInfo();
                academicStudentServiceInfo.AcademicStudentId = academicStudent.AcademicStudentId;
                academicStudentServiceInfo.StudentId = academicStudent.StudentId;
                academicStudentServiceInfo.AcademicId = academicStudent.AcademicId;
                academicStudentServiceInfo.ClassId = academicStudent.ClassId;
                academicStudentServiceInfo.GroupId = academicStudent.GroupId;
                var academicStudentList = _academicStudentService.AddAcademicStudent(academicStudentServiceInfo);
                return Ok(academicStudentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateAcademicStudent")]
        public async Task<IActionResult> UpdateAcademicStudent(AcademicStudentModel academicStudent)
        {
            try
            {
                var academicStudentServiceInfo = new AcademicStudentServiceInfo();
                academicStudentServiceInfo.AcademicStudentId = academicStudent.AcademicStudentId;
                academicStudentServiceInfo.StudentId = academicStudent.StudentId;
                academicStudentServiceInfo.AcademicId = academicStudent.AcademicId;
                academicStudentServiceInfo.ClassId = academicStudent.ClassId;
                academicStudentServiceInfo.GroupId = academicStudent.GroupId;
                var academicStudentList = _academicStudentService.UpdateAcademicStudent(academicStudentServiceInfo);
                return Ok(academicStudentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteAcademicStudent")]
        public async Task<IActionResult> DeleteAcademicStudent(long AcademicStudentId)
        {
            try
            {
               var academicStudentList = _academicStudentService.DeleteAcademicStudent(AcademicStudentId);
                return Ok(academicStudentList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
