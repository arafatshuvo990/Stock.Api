using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Stock.Api.Data;
using Stock.Api.Dtos.Comments;
using Stock.Api.Helpers;
using Stock.Api.Interfaces;
using Stock.Api.Models;

namespace Stock.Api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository( ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Comments> CreateAsync(Comments commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;

        }

        public Task<Comments?> DeleteAsync(int id)
        {
            var oldComment = _context.Comments.FirstOrDefault(c => c.Id == id);
            if (oldComment == null)
                return Task.FromResult<Comments?>(null);
            _context.Comments.Remove(oldComment);
            _context.SaveChanges();
            return Task.FromResult<Comments?>(oldComment);
        }

        public async Task<List<Comments>> GetAllAsync()
        {
            return await _context.Comments
                .Include(c => c.Stock)
                .ToListAsync();
        }



        public async Task<Comments?> GetByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comments?> UpdateAsync(int id, UpdateCommentDto commentDto)
        {
            var existingComment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (existingComment == null)
                return null;
            existingComment.Title = commentDto.Title;
            existingComment.Content = commentDto.Content;

            await _context.SaveChangesAsync();
            return existingComment;
        }
    }
}
