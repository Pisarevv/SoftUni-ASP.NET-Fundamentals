using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.Web.Controllers
{
    public class BoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
