using Microsoft.EntityFrameworkCore;
using Stock.Api.Data;
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
            throw new NotImplementedException();
        }

        public async Task<List<Comments>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public Task<Comments?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Comments?> UpdateAsync(int id, Comments commentModel)
        {
            throw new NotImplementedException();
        }
    }
}
