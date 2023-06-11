namespace TaskBoard.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TaskBoard.Core.Contracts;
    using TaskBoard.Core.Models.Task;
    using TaskBoard.Web.Extensions;

    public class TaskController : Controller
    {
        private readonly IBoardService boardService;
        private readonly ITaskService taskService;

        public TaskController(IBoardService boardService, ITaskService taskService)
        {
            this.boardService = boardService;
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TaskFormModel model = new TaskFormModel()
            {
               
            };
            var boards = await boardService.GetBoardsForSelectAsync();
            model.Boards = boards;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel inputModel)
        {
            bool boardExist = await boardService.DoesExists(inputModel.BoardId);
            if (!boardExist)
            {
                ModelState.AddModelError(nameof(inputModel.BoardId), "Board does not exist");
            }

            if(!ModelState.IsValid)
            {
                var boards = await boardService.GetBoardsForSelectAsync();
                inputModel.Boards = boards;
                return View(inputModel);
            }

            string currentUserId = this.User.GetId();

            await taskService.Add(currentUserId, inputModel);


            return RedirectToAction("All", "Board");
        }
    }
}
