namespace Forum.Infrastructure.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Forum.Common.Validation.ValidationConstants.Post;
    public class Post
    {
        public Post()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(MinTitleLenght)]
        [MaxLength(MaxTitleLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(MinTitleLenght)]
        [MaxLength(MaxTitleLenght)]
        public string Content { get; set; } = null!;
    }
}
