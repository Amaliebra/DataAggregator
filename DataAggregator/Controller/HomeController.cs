using Microsoft.AspNetCore.Mvc;

namespace DataAggregator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
