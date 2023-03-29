using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using SchoolManagementService;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        [Route("GetClass")]
        public IActionResult GetClass()
        {
            try
            {
                var classList = _classService.GetClass();
                return Ok(classList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetClassId")]
        public async Task<IActionResult> GetClassId(long ClassId)
        {
            try
            {
                var classList = _classService.GetClassId(ClassId);
                return Ok(classList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddClass")]
        public async Task<IActionResult> AddClass(ClassModel classes)
        {
            try
            {
                var classServiceInfo = new ClassServiceInfo();
                classServiceInfo.ClassName = classes.ClassName;
                classServiceInfo.Section = classes.Section;
                classServiceInfo.AcademicId = classes.AcademicId;
                var classList = _classService.AddClass(classServiceInfo);
                return Ok(classList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateClass")]
        public async Task<IActionResult> UpdateClass(ClassModel classes)
        {
            try
            {
                var classServiceInfo = new ClassServiceInfo();
                classServiceInfo.ClassId = classes.ClassId;
                classServiceInfo.ClassName = classes.ClassName;
                classServiceInfo.Section = classes.Section;
                classServiceInfo.AcademicId = classes.AcademicId;
                var classList = _classService.UpdateClass(classServiceInfo);
                return Ok(classList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteClass")]
        public async Task<IActionResult> DeleteClass(long ClassId)
        {
            try
            {
               var classList = _classService.DeleteClass(ClassId);
                return Ok(classList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
