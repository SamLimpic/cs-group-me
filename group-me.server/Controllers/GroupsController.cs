using System;
using System.Collections.Generic;
using group_me.server.Models;
using group_me.server.Services;
using Microsoft.AspNetCore.Mvc;

namespace group_me.server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
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
    }
}