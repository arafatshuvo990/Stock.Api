using Stock.Api.Models;

namespace Stock.Api.Dtos.Comments
{
    public class CommentDtos
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
       
    }
}
