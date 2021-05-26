using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using group_me.server.Models;
using group_me.server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace group_me.server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupMembersController : ControllerBase
    {
        private readonly GroupMembersService _service;

        public GroupMembersController(GroupMembersService service)
        {
            _service = service;
        }



        [HttpGet]
        public ActionResult<List<GroupMemberView>> GetAll(int groupId)
        {
            try
            {
                List<GroupMemberView> groups = _service.GetAll(groupId);
                return groups;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GroupMemberDTO>> Create([FromBody] GroupMemberDTO data)
        {
            try
            {
                // REVIEW Enforce the current user context
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                data.AccountId = userInfo.Id;
                GroupMemberDTO newMember = _service.Create(data);
                return Ok(newMember);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}