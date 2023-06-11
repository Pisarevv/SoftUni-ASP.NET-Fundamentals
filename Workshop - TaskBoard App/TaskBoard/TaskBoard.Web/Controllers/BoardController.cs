using Microsoft.AspNetCore.Mvc;
using TaskBoard.Core.Contracts;

namespace TaskBoard.Web.Controllers
{
    public class BoardController : Controller
    {
        private readonly IBoardService boardService;
        public BoardController(IBoardService boardService)
        {
            this.boardService = boardService;
        }
        public async Task<IActionResult> All()
        { 
            try
            {
                var boards = await boardService.GetAllAsync();
                return View(boards);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}
