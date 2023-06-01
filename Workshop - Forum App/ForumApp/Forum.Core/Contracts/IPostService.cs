namespace Forum.Core.Contracts
{
    using Forum.Core.Models.Post;
    public interface IPostService
    {
        public Task<ICollection<PostViewModel>> GetAllAsync();
    }
}
