namespace Forum.Infrastructure.Data.Seeding
{
    using Models;
    class PostSeeder
    {
        internal Post[] GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();

            Post post = new Post
            {
                Title = "My first post",
                Content = "My first post will be about performing CRUD operations in MVC. It is so mutch fun!",
            };

            posts.Add(post);

            post = new Post
            {
                Title = "My second post",
                Content = "The Second post will also be about performing CRUD operations in MVC. It is so mutch fun!",
            };

            posts.Add(post);

            post = new Post
            {
                Title = "My third",
                Content = "Hello ! My third post will be about performing CRUD operations in MVC YAY. It is so mutch fun!",
            };

            posts.Add(post);


            return posts.ToArray();

        }
    }
}
