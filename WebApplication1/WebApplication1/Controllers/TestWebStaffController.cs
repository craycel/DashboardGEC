using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TestWebStaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}