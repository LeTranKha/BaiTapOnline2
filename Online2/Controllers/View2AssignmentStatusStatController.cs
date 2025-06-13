using Microsoft.AspNetCore.Mvc;
using Online2.Data;
using Online2.Models;

namespace Online2.Controllers
{
    public class View2AssignmentStatusStatController : Controller
    {
        // Action để hiển thị dữ liệu từ View2_AssignmentStatusStats
        public IActionResult Index()
        {
            StudentManagerDbContext gameContext = new StudentManagerDbContext();
            List<View2AssignmentStatusStat> deadlinelist =
                gameContext.View2AssignmentStatusStats.ToList();
            return View(deadlinelist);
        }
    }
}
