namespace TaskBoard.Infrastructure.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Task = Data.Models.Task;

    internal class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
               .HasOne(t => t.Board)
               .WithMany(b => b.Tasks)
               .HasForeignKey(t => t.BoardId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(GenerateTasks());
        }

        private ICollection<Task> GenerateTasks()
        {
            ICollection<Task> tasks = new HashSet<Task>()
            {
                new Task()
                {
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.UtcNow.AddDays(-200),
                    OwnerId = "0d854fc1-5c0d-4645-b1bc-e486e94cde9b",
                    BoardId = 1
                },
                new Task()
                {
                    Title = "Android Client App",
                    Description = "Create Android client App for the RESTful TaskBoard service",
                    CreatedOn = DateTime.UtcNow.AddMonths(-5),
                    OwnerId = "0d854fc1-5c0d-4645-b1bc-e486e94cde9b",
                    BoardId = 1
                },
                new Task()
                {
                    Title = "Desktop Client App",
                    Description = "Create Desktop client App for the RESTful TaskBoard service",
                    CreatedOn = DateTime.UtcNow.AddMonths(-1),
                    OwnerId = "0d854fc1-5c0d-4645-b1bc-e486e94cde9b",
                    BoardId = 2
                },
                new Task()
                {
                    Title = "Create Tasks",
                    Description = "Implement [Create Task] page for adding tasks",
                    CreatedOn = DateTime.UtcNow.AddYears(-1),
                    OwnerId = "dbc68811-2d8b-4559-97b5-96faaee5e38c",
                    BoardId = 3
                }
            };

            return tasks;
        }
    }
    
}
