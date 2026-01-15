using Microsoft.AspNetCore.Mvc;

namespace project1.Controllers
{
    public class SalaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
