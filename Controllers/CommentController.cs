using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock.Api.Data;
using Stock.Api.Dtos.Comments;
using Stock.Api.Interfaces;
using Stock.Api.Mapper;
using Stock.Api.Repository;

namespace Stock.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICommentRepository _commentRepository;
        public CommentController(ApplicationDbContext context, ICommentRepository commentRepository)
        {
            _context = context;
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentDtos = comments.Select(c => c.ToCommentDto());
            return Ok(commentDtos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentDto commentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = commentDto.ToCommentModel();

           
            var createdComment = await _commentRepository.CreateAsync(comment);

            var commentResponse = createdComment.ToCommentDto();

            return CreatedAtAction(nameof(GetComment), new { id = createdComment.Id }, commentResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (deleted == null)
            {
                return NotFound("Comment not found");
            }

            _context.Comments.Remove(deleted);
            await _context.SaveChangesAsync();    

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCommentDto updateCommentDto)
        {
         
            var existing = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
                return NotFound("Comment not found");

         
            existing.Title = updateCommentDto.Title;
            existing.Content = updateCommentDto.Content;
           

          
            await _context.SaveChangesAsync();

            var updatedDto = existing.ToCommentDto();

            return Ok(updatedDto);
        }




    }
}
