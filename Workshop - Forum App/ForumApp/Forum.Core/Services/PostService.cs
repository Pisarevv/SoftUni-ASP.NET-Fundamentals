using Forum.Core.Contracts;
using Forum.Core.Models.Post;
using Forum.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Forum.Core.Services
{
    public class PostService : IPostService
    {
        private readonly ForumDbContext _context;
        public PostService(ForumDbContext context) 
        {
            this._context = context;
        }

        public async Task<ICollection<PostViewModel>> GetAllAsync()
        {
            var allPosts = await _context.Posts
                   .Select(p => new PostViewModel
                   {
                       Id = p.Id.ToString(),
                       Title = p.Title,
                       Content = p.Content
                   }
                   )
                   .ToListAsync();

            return allPosts;
        }
    }
}


