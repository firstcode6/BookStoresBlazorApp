using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : Controller
    {
        private readonly IPublisherRepository _publisherRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="publisherRepository"></param>
        public PublishersController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        #region HTTP request methods

        /// <summary>
        /// GET: api/Publishers
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPublishers")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Publisher>))]
        public async Task<ActionResult<List<Publisher>>> GetPublishers()
        {
            var publishers = await _publisherRepository.GetPublishers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(publishers);
        }

        /// <summary>
        /// Create POST: api/Publishers 
        /// </summary>
        /// <param name="newPublisher"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostPublisher([FromBody] Publisher newPublisher)
        {
            if (newPublisher == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            if (!await _publisherRepository.CreatePublisher(newPublisher))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        #endregion
    }
}
