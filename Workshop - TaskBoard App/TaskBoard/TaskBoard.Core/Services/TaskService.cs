﻿using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
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

        public async Task AddAsync(string OwnerId,TaskFormModel inputModel)
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

        public async Task<TaskDetailsViewModel> GetDetailsAsync(string taskId)
        {
            try
            {
                var foundTask = await dbContext.Tasks
                                .Select(x => new TaskDetailsViewModel()
                                {
                                    Id = x.Id.ToString(),
                                    Description = x.Description,
                                    Title = x.Title,
                                    Owner = x.Owner.UserName,
                                    Board = x.Board.Name,
                                    CreatedOn = x.CreatedOn.ToString("dddd, dd MMMM yyyy HH:mm:ss")
                                })
                                .FirstOrDefaultAsync(t => t.Id == taskId);

                if (foundTask == null)
                {
                    throw new Exception("Task cannot be found");
                }


                return foundTask;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
