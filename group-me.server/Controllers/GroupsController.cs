using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using group_me.server.Models;
using group_me.server.Services;
using group_me.server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace group_me.server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase, IController<Group>
    {
        private readonly GroupsService _service;

        public GroupsController(GroupsService service)
        {
            _service = service;
        }



        [HttpGet]
        public ActionResult<List<Group>> GetAll()
        {
            try
            {
                List<Group> groups = _service.GetAll();
                return groups;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}")]
        public ActionResult<Group> GetById(int id)
        {
            throw new NotImplementedException();
        }



        [HttpPost]
        public Task<ActionResult<Group>> Create([FromBody] Group newGroup)
        {
            throw new NotImplementedException();
        }



        [HttpPut("{id}")]
        public async Task<ActionResult<Group>> Update([FromBody] Group edit, int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                edit.Id = id;
                Group update = _service.Update(edit, userInfo.Id);
                return Ok(update);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Group>> Delete(int id)
        {
            try
            {
                // TODO[epic=Auth] Get the user info to set the creatorID
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                // safety to make sure an account exists for that user before DELETE-ing stuff.
                _service.Delete(id, userInfo.Id);
                return Ok("Successfully Deleted!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}