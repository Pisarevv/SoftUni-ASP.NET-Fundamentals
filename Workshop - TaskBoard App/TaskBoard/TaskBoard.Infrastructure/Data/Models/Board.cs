namespace TaskBoard.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static TaskBoard.Common.ValidationConstants.Board;
    public class Board
    {
        public Board()
        {
            this.Id = Guid.NewGuid();
            this.Tasks = new HashSet<Task>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Task> Tasks { get; set; }

    }
}
