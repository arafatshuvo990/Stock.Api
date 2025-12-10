using Stock.Api.Dtos.Comments;
using Stock.Api.Models;

namespace Stock.Api.Mapper
{
    public static class CommentMapper
    {
        public static CommentDtos ToCommentDto(this Comments comment)
        {
            return new CommentDtos
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn
            };
            
        }
        public static Comments ToCommentModel(this CreateCommentDto createCommentDto)
        {
            return new Comments
            {
                Title = createCommentDto.Title,
                Content = createCommentDto.Content,
                StockId = createCommentDto.StockId,
                CreatedOn = createCommentDto.CreatedOn
            };
        }
    }
}
