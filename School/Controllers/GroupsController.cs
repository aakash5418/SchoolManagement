using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using SchoolManagementService;

namespace School.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupsService _groupsService;
        public GroupsController(IGroupsService groupsService)
        {
            _groupsService = groupsService;
        }

        [HttpGet]
        [Route("GetGroups")]
        public IActionResult GetGroups()
        {
            try
            {
                var groupList = _groupsService.GetGroups();
                return Ok(groupList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetGroupsId")]
        public async Task<IActionResult> GetGroupsId(long GroupId)
        {
            try
            {
                var groupList = _groupsService.GetGroupsId(GroupId);
                return Ok(groupList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddGroups")]
        public async Task<IActionResult> AddGroups(GroupsModel groups)
        {
            try
            {
                var groupsServiceInfo = new GroupsServiceInfo();
                groupsServiceInfo.GroupName = groups.GroupName;
                var groupList = _groupsService.AddGroups(groupsServiceInfo);
                return Ok(groupList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateGroups")]
        public async Task<IActionResult> UpdateGroups(GroupsModel groups)
        {
            try
            {
                var groupsServiceInfo = new GroupsServiceInfo();
                groupsServiceInfo.GroupId = groups.GroupId;
                groupsServiceInfo.GroupName = groups.GroupName;
               var groupList = _groupsService.UpdateGroups(groupsServiceInfo);
                return Ok(groupList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteGroups")]
        public async Task<IActionResult> DeleteGroups(long GroupId)
        {
            try
            {
              var groupList =  _groupsService.DeleteGroups(GroupId);
                return Ok(groupList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
