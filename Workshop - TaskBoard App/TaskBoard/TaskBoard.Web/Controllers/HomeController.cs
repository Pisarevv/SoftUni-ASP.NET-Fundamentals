using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskBoard.Core.Models;

namespace TaskBoard.Web.Controllers
{
    public class HomeController : Controller
    {
     
        public IActionResult Index()
        {
            return View();
        }

       
    }
}