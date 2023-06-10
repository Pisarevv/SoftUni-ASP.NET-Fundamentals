using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.Web.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
