using TaskBoard.Core.Contracts;
using TaskBoard.Core.Models.Task;
using TaskBoard.Infrastructure.Data;

namespace TaskBoard.Core.Services
{

    public class TaskService : ITaskService
    {
        private readonly TaskBoardAppDbContext dbContext;
        public TaskService(TaskBoardAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(string OwnerId,TaskFormModel inputModel)
        {
            Infrastructure.Data.Models.Task newTask = new Infrastructure.Data.Models.Task()
            {
               Title = inputModel.Title,
               Description = inputModel.Description,
               BoardId = inputModel.BoardId,
               CreatedOn = DateTime.UtcNow,
               OwnerId = OwnerId
            };

            await dbContext.Tasks.AddAsync(newTask);
            await dbContext.SaveChangesAsync();
        }
    }
}
