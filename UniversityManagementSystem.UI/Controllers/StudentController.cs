using Microsoft.AspNetCore.Mvc;

namespace UniversityManagementSystem.UI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
