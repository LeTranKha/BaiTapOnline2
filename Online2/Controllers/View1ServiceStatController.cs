using Microsoft.AspNetCore.Mvc;
using Online2.Data;
using Online2.Models;

namespace Online2.Controllers
{
    public class View1ServiceStatController : Controller
    {
        // Action để hiển thị dữ liệu từ View1_ServiceStats
        public IActionResult Index()
        {
            StudentManagerDbContext gameContext = new StudentManagerDbContext();
            List<View1ServiceStat> deadlinelist =
                gameContext.View1ServiceStats.ToList();
            return View(deadlinelist);
        }

    }
}
