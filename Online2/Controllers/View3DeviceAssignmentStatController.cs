using Microsoft.AspNetCore.Mvc;
using Online2.Data;
using Online2.Models;

namespace Online2.Controllers
{
    public class View3DeviceAssignmentStatController : Controller
    {
        // Action để hiển thị dữ liệu từ View3_DeviceAssignmentStats
        public IActionResult Index()
        {
            StudentManagerDbContext gameContext = new StudentManagerDbContext();
            List<View3DeviceAssignmentStat> deadlinelist =
                gameContext.View3DeviceAssignmentStats.ToList();
            return View(deadlinelist);

        }
    }
}
