using Microsoft.AspNetCore.Mvc;
using School.Models;
using SchoolManagementService;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectsService _subjectsService;
        public SubjectsController(ISubjectsService subjectsService)
        {
            _subjectsService = subjectsService;
        }

        [HttpGet]
        [Route("GetSubjects")]
        public IActionResult GetSubjects()
        {
            try
            {
                var subjectsList = _subjectsService.GetSubjects();
                return Ok(subjectsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetSubjectsId")]
        public async Task<IActionResult> GetSubjectsId(long SubjectId)
        {
            try
            {
                var subjectsList = _subjectsService.GetSubjectsId(SubjectId);
                return Ok(subjectsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddSubjects")]
        public async Task<IActionResult> AddSubjects(SubjectsModel subjects)
        {
            try
            {
                var subjectServiceInfo = new SubjectsServiceInfo();
                subjectServiceInfo.SubjectId = subjects.SubjectId;
                subjectServiceInfo.SubjectName = subjects.SubjectName;
                subjectServiceInfo.SubjectCode = subjects.SubjectCode;
                subjectServiceInfo.GroupId = subjects.GroupId;
                var subjectList = _subjectsService.AddSubjects(subjectServiceInfo);
                return Ok(subjectList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("UpdateSubjects")]
        public async Task<IActionResult> UpdateSubjects(SubjectsModel subjects)
        {
            try
            {
                var subjectServiceInfo = new SubjectsServiceInfo();
                subjectServiceInfo.SubjectId = subjects.SubjectId;
                subjectServiceInfo.SubjectName = subjects.SubjectName;
                subjectServiceInfo.SubjectCode = subjects.SubjectCode;
                subjectServiceInfo.GroupId = subjects.GroupId;
                var subjectList = _subjectsService.UpdateSubjects(subjectServiceInfo);
                return Ok(subjectList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteSubjects")]
        public async Task<IActionResult> DeleteSubjects(long SubjectId)
        {
            try
            {
               var subjectList = _subjectsService.DeleteSubjects(SubjectId);
                return Ok(subjectList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
