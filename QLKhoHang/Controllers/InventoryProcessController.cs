using Microsoft.AspNetCore.Mvc;

namespace QLKhoHang.Controllers
{
    public class InventoryProcessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
