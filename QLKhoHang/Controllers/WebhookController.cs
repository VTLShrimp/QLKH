using Microsoft.AspNetCore.Mvc;

namespace QLKhoHang.Controllers
{
    public class WebhookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
