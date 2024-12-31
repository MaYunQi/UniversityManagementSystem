using Microsoft.AspNetCore.Mvc;

namespace UniversityManagementSystem.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
