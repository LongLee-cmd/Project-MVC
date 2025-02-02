using Microsoft.AspNetCore.Mvc;
using waHoadon.Models;

namespace HoaDon.Controllers
{
    public class ChitietHoaDonController : Controller
    {
        hoadonContext db = new hoadonContext();
          
        public IActionResult Index()
        {
            return View(db.Chitiethoadons.ToList());
        }
        public IActionResult Create_Chitiethoadon()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create_Chitiethoadon(Chitiethoadon cthd)
        {
            db.Chitiethoadons.Add(cthd);
            db.SaveChanges();
            return View();
        }
    }
}
