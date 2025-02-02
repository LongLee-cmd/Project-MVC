using Microsoft.AspNetCore.Mvc;
using waHoadon.Models;

namespace HoaDon.Controllers
{
    public class HangHoaController : Controller
    {
        hoadonContext db = new hoadonContext();
        public IActionResult Index()
        {

            hoadonContext db = new hoadonContext();
            return View(db.Hanghoas.ToList());
        }
        public IActionResult Create_HangHoa()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create_HangHoa(Hanghoa hh)
        {
            db.Hanghoas.Add(hh);
            db.SaveChanges();
            return View();
        }
        public IActionResult Edit_HangHoa(string id)
        {
            Hanghoa hh = db.Hanghoas.Find(id);
            return View(hh);
        }
        [HttpPost]
        public IActionResult Edit_HangHoa(Hanghoa hh)
        {
            Hanghoa hhh = db.Hanghoas.Find(hh.Mahang);
            hhh.Tenhang = hh.Tenhang;
            hhh.Dongia = hh.Dongia;
            hhh.Dvt = hh.Dvt;
            db.SaveChanges();
            return View();
        }
        [HttpPost]
        public IActionResult Delete_HangHoa(int? id)
        {
            Hanghoa hh= db.Hanghoas.Find(id);
            return View(hh);
        }
        [HttpPost]
        public IActionResult Delete_HangHoa(int id)
        {
            Hanghoa hh = db.Hanghoas.Find(id);
            db.Hanghoas.Remove(hh);
            db.SaveChanges();
            return View();
        }
    }
}
