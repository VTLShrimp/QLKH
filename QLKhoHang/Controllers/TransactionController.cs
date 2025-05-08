using Microsoft.AspNetCore.Mvc;

namespace QLKhoHang.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
