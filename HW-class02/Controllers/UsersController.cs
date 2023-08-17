using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_Class02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> GetAll()
        {
            var users = StaticDb.Users;

            return StatusCode(StatusCodes.Status200OK, users);
        }

        [HttpGet("index")]                //https:localhost:[]/api/users/index
        public ActionResult<string> GetByIndex(int index)
        {
            try
            {
                if(index < 0)
                {
                    return BadRequest("The value of the index can't be a negative number");
                }

                if(index >= StaticDb.Users.Count)
                {
                    return NotFound($"The user on index {index} doesn't exist, please enter a value between 0 and {StaticDb.Users.Count - 1}");
                }

                return Ok(StaticDb.Users[index]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, please try again later");
            }
        }
    }
}
