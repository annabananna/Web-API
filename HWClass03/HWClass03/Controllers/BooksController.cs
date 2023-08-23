using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_Class03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(StaticDb.Books);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend, please try again later");
            }
        }

        [HttpGet("{index}")]
        public IActionResult GetByIndex(int index)
        {
            try
            {
                if(index < 0)
                {
                    return BadRequest("Index can't be a negative number");
                }

                if(index >= StaticDb.Books.Count)
                {
                    return NotFound($"The element on index {index} does not exist");
                }

                return Ok(StaticDb.Books[index]);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend, please try again later");
            }
        }

        [HttpGet("filter")]
        public IActionResult FilterBooks(string? author, string? title)
        {
            var query = StaticDb.Books;

            if(!string.IsNullOrEmpty(author))
            {
                query = query.Where(x => x.Author.ToLower().Contains(author.ToLower())).ToList();
            }

            if(!string.IsNullOrEmpty(title))
            {
                query = query.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
            }

            return Ok(query);
        }
    }
}
