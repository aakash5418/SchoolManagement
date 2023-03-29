using Microsoft.AspNetCore.Mvc;
using School.Models;
using SchoolManagementService;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly IMarksService _marksService;
        public MarksController(IMarksService marksService)
        {
            _marksService = marksService;
        }

        [HttpGet]
        [Route("GetMarks")]

        public IActionResult GetMarks()
        {
            var marksList = _marksService.GetMarks();
            return Ok(marksList);
        }

        [HttpGet]
        [Route("GetMarksId")]

        public async Task<IActionResult> GetMarksId(long MarkId)
        {
            var marksList = _marksService.GetMarksId(MarkId);
            return Ok(marksList);
        }

        [HttpPost]
        [Route("AddMarks")]

        public async Task<IActionResult> AddMarks(MarksModel marks)
        {
            try
            {
                var marksServiceInfo = new MarksServiceInfo();
                marksServiceInfo.MarksId = marks.MarksId;
                marksServiceInfo.MarksObtained = marks.MarksObtained;
                marksServiceInfo.TotalMarksObtained = marks.TotalMarksObtained;
                marksServiceInfo.AcademicStudentId = marks.AcademicStudentId;
                marksServiceInfo.ExamId = marks.ExamId;
                marksServiceInfo.SubjectId = marks.SubjectId;
                var marksList =  _marksService.AddMarks(marksServiceInfo);
                return Ok(marksList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateMarks")]

        public async Task<IActionResult> UpdateMarks(MarksModel marks)
        {
            try
            {
                var marksServiceInfo = new MarksServiceInfo();
                marksServiceInfo.MarksId = marks.MarksId;
                marksServiceInfo.MarksObtained = marks.MarksObtained;
                marksServiceInfo.TotalMarksObtained = marks.TotalMarksObtained;
                marksServiceInfo.AcademicStudentId = marks.AcademicStudentId;
                marksServiceInfo.ExamId = marks.ExamId;
                marksServiceInfo.SubjectId = marks.SubjectId;
                var marksList =  _marksService.UpdateMarks(marksServiceInfo);
                return Ok(marksList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteMarks")]

        public async Task<IActionResult> DeleteMarks(long MarkId)
        {
           var marksList = _marksService.DeleteMarks(MarkId);
            return Ok(marksList);
        }
    }
}
