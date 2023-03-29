using Microsoft.AspNetCore.Mvc;
using SchoolManagementService;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkListController : ControllerBase
    {
        private readonly IMarksListService _marksListService;
        public MarkListController(IMarksListService marksListService)
        {
            _marksListService = marksListService;
        }

        [HttpGet]
        [Route("GetMarKsList")]
        public async Task<IActionResult> GetMarksList(long AcademicId, string ExamType, string ClassName)
        {
            try
            {
                var markList = _marksListService.GetMarksList(AcademicId, ExamType, ClassName);
                return Ok(markList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetSubjectWiseMarks")]
        public IActionResult GetSubjectWiseMarks()
        {
            try
            {
                var markList = _marksListService.GetSubjectWiseMarks();
                return Ok(markList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetStudentRollNo")]
        public async Task<IActionResult> GetStudentRollNo(string RollNo)
        {
            try
            {
                var markList = _marksListService.GetStudentRollNo(RollNo);
                return Ok(markList);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
