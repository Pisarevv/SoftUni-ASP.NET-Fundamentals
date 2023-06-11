using TaskBoard.Core.Models.Task;

namespace TaskBoard.Core.Contracts
{
    public interface ITaskService
    {
        public Task AddAsync(string OwnerId,TaskFormModel inputModel);

        public Task<TaskDetailsViewModel> GetDetailsAsync(string taskId);

        public Task EditAsync(string taskId, TaskFormModel inputModel);

        public Task<TaskFormModel> GetById(string taskId);
    }
}
