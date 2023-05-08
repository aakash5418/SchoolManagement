using Microsoft.AspNetCore.Mvc;
using School.Models;
using SchoolManagementService;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicController : ControllerBase
    {
        private readonly IAcademicService _academicService;
        public AcademicController(IAcademicService academicService)
        {
            _academicService = academicService;
        }

        [HttpGet]
        [Route("GetAcademic")]
        public IActionResult GetAcademic()
        {
            try
            {
                var academicList = _academicService.GetAcademic();
                return Ok(academicList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAcademicId")]
        public async Task<IActionResult> GetAcademicId(long AcademicId)
        {
            try
            {
                var academicList = _academicService.GetAcademicId(AcademicId);
                return Ok(academicList);
            }
            catch (Exception ex)
            {
                                return Ok(new { msg = "AcademicId  Not Found" });

            }
        }

        [HttpPost]
        [Route("AddAcademic")]
        public async Task<IActionResult> AddAcademic(AcademicModel academic)
        {
            try
            {
                var academicServiceInfo = new AcademicServiceInfo();
                academicServiceInfo.AcademicId = academic.AcademicId;
                academicServiceInfo.AcademicStartYear = academic.AcademicStartYear;
                academicServiceInfo.AcademicEndYear = academic.AcademicEndYear;
               var academicList =   _academicService.AddAcademic(academicServiceInfo);
                return Ok(academicList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateAcademic")]
        public async Task<IActionResult> UpdateAcademic(AcademicModel academic)
        {
            try
            {
                var academicServiceInfo = new AcademicServiceInfo();
                academicServiceInfo.AcademicId = academic.AcademicId;
                academicServiceInfo.AcademicStartYear = academic.AcademicStartYear;
                academicServiceInfo.AcademicEndYear = academic.AcademicEndYear;
                var academicList = _academicService.UpdateAcademic(academicServiceInfo);
                return Ok(academicList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteAcademic")]
        public async Task<IActionResult> DeleteAcademic(long AcademicId)
        {
            try
            {
              var academicList =  _academicService.DeleteAcademic(AcademicId);
                return Ok(academicList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
