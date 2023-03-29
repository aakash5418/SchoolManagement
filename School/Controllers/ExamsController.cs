using Microsoft.AspNetCore.Mvc;
using School.Models;
using SchoolManagementService;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamsService _examService;
        public ExamsController(IExamsService examsService)
        {
            _examService = examsService;
        }

        [HttpGet]
        [Route("GetExams")]
        public IActionResult GetExams()
        {
            try
            {
                var examsList = _examService.GetExams();
                return Ok(examsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetExamsId")]
        public async Task<IActionResult> GetExamsId(long ExamId)
        {
            try
            {
                var examsList = _examService.GetExamsId(ExamId);
                return Ok(examsList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddExams")]
        public async Task<IActionResult> AddExams(ExamsModel exams)
        {
            try
            {
                var examServiceInfo = new ExamsServiceInfo();
                examServiceInfo.ExamId = exams.ExamId;
                examServiceInfo.ExamType = exams.ExamType;
                examServiceInfo.AcademicId = exams.AcademicId;
                var examList = _examService.AddExams(examServiceInfo);
                return Ok(examList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateExams")]
        public async Task<IActionResult> UpdateExams(ExamsModel exams)
        {
            try
            {
                var examServiceInfo = new ExamsServiceInfo();
                examServiceInfo.ExamId = exams.ExamId;
                examServiceInfo.ExamType = exams.ExamType;
                examServiceInfo.AcademicId = exams.AcademicId;
                var examList = _examService.UpdateExams(examServiceInfo);
                return Ok(examList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteExams")]
        public async Task<IActionResult> DeleteExams(long ExamId)
        {
            try
            {
               var examList = _examService.DeleteExams(ExamId);
                return Ok(examList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
