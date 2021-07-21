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
    public class TasksController: ControllerBase
    {
        private readonly TasksService _ts;

        public TasksController(TasksService ts)
        {
            _ts = ts;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Models.Task>> Create([FromBody] Models.Task taskData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                taskData.CreatorId = userInfo.Id;
                var t = _ts.CreateTask(taskData);
                return Ok(t);
            }
            catch (System.Exception e)
            {
                
            return BadRequest(e.Message);        

        }

    }


}
}