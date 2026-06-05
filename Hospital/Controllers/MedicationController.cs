using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class MedicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
