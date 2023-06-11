using TaskBoard.Core.Models.Task;

namespace TaskBoard.Core.Contracts
{
    public interface ITaskService
    {
        public Task AddAsync(string OwnerId,TaskFormModel inputModel);

        public Task<TaskDetailsViewModel> GetDetailsAsync(string taskId);
    }
}
