using System.ComponentModel.DataAnnotations;

namespace Stock.Api.Dtos.Comments
{
    public class UpdateCommentDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Content must be between 5 and 500 characters.")]
        public string Content { get; set; } = string.Empty;
    }
}
