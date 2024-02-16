using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="authorRepository"></param>
        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        #region HTTP request methods

        /// <summary>
        /// GET: api/Authors
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAuthors")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Author>))]
        public async Task<ActionResult<List<Author>>> GetAuthors()
        {
            var authors = await _authorRepository.GetAuthors();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(authors);
        }

        /// <summary>
        /// GET: api/Author
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAuthor/{id}")]
        [ProducesResponseType(200, Type = typeof(Author))]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _authorRepository.GetAuthorById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(author);
        }

        /// <summary>
        /// GET: api/
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDate")]
        [ProducesResponseType(200, Type = typeof(DateTime))]
        public ActionResult<DateTime> GetDate()
        {
            var date = _authorRepository.GetCreatedDate();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(date);
        }

        /// <summary>
        /// DELETE: api/Authors/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _authorRepository.DeleteAuthor(id))
            {
                ModelState.AddModelError("", "Something went wrong deleting author");
            }

            return NoContent();
        }

        /// <summary>
        /// Create POST: api/Authors 
        /// </summary>
        /// <param name="newAuthor"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostAuthor([FromBody] Author newAuthor)
        {
            if (newAuthor == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _authorRepository.CreateAuthor(newAuthor))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        /// <summary>
        /// Update PUT: api/Authors/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateAuthor"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutAuthor(int id, [FromBody] Author updateAuthor)
        {
            if (updateAuthor == null || id != updateAuthor.Id)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            if (!await _authorRepository.UpdateAuthor(updateAuthor, id))
            {
                ModelState.AddModelError("", "Something went wrong updating author");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }




        #endregion
    }
}
