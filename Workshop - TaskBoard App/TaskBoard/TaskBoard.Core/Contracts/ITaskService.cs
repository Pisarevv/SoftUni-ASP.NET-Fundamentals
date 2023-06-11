using TaskBoard.Core.Models.Task;

namespace TaskBoard.Core.Contracts
{
    public interface ITaskService
    {
        public Task Add(string OwnerId,TaskFormModel inputModel);
    }
}
