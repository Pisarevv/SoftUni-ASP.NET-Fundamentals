﻿namespace Forum.Core.Contracts
{
    using Forum.Core.Models.Post;
    using Forum.Infrastructure.Data.Models;

    public interface IPostService
    {
        public Task<ICollection<PostViewModel>> GetAllAsync();

        public Task CreateAsync(PostFormModel model);

        public Task<Post> GetByIdAsync (string id);


        public Task UpdateAsync(string id, PostFormModel model);

        public Task Delete(string id);

    }
}
