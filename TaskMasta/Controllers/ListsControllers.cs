using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskMasta.Models;
using TaskMasta.Services;

namespace TaskMasta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListsController: ControllerBase
    {
        private readonly ListsService _ls;
        public ListsController(ListsService ls)
        {
            _ls = ls;
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<List>>> Get(string id)
        {

            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                id = userInfo.Id;
               List<List> lists = _ls.GetListsById(id);
                return Ok(lists);
        
                
            }
            catch (System.Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<List>> Create([FromBody] List listData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                listData.CreatorId = userInfo.Id;
                listData.Profile = userInfo;
                var l = _ls.CreateList(listData);
                return Ok(l);
            
            }
            catch (System.Exception e)
            {
                
                return  BadRequest(e.Message);
            }
        }

    }
}