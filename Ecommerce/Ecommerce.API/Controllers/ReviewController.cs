using Ecommerce.Application.Services;
using Ecommerce.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: api/review/product/{productId}
        [HttpGet("product/{productId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByProduct(int productId)
        {
            var reviews = await _reviewService.GetReviewsByProductAsync(productId);
            if (reviews == null)
            {
                return NotFound();
            }
            return Ok(reviews);
        }

        // GET: api/review/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByUser(int userId)
        {
            var reviews = await _reviewService.GetReviewsByUserAsync(userId);
            if (reviews == null)
            {
                return NotFound();
            }
            return Ok(reviews);
        }

        // POST: api/review
        [HttpPost]
        public async Task<ActionResult> AddReview([FromBody] Review review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _reviewService.AddReviewAsync(review);
            return CreatedAtAction(nameof(GetReviewsByProduct), new { productId = review.ProductId }, review);
        }

        // PUT: api/review/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReview(int id, [FromBody] Review review)
        {
            if (id != review.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            await _reviewService.UpdateReviewAsync(review);
            return NoContent();
        }

        // DELETE: api/review/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}
