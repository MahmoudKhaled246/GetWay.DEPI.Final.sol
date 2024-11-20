using Microsoft.AspNetCore.Mvc;

namespace Auth.DEPI.Final.PL.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
