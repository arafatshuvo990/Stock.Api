using Stock.Api.Dtos.Comments;
using Stock.Api.Models;

namespace Stock.Api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comments>> GetAllAsync();
        Task<Comments?> GetByIdAsync(int id);
        Task<Comments> CreateAsync(Comments commentModel);
        Task<Comments?> UpdateAsync(int id, UpdateCommentDto updateCommentDto);
        Task<Comments?> DeleteAsync(int id);
    }
}
