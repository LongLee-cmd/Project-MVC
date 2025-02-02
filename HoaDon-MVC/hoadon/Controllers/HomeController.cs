using HoaDon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Common;
using System.Diagnostics;
using waHoadon.Models;
namespace HoaDon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        hoadonContext db = new hoadonContext();
       

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            hoadonContext db = new hoadonContext();
            return View(db.Hoadons.ToList());
        }
        public IActionResult Create_HoaDon()
        {
        
            return View();
        }
        [HttpPost]
        public IActionResult Create_HoaDon(Hoadon hd)
        {
            db.Hoadons.Add(hd);
            db.SaveChanges();
            return View();
        }
        [HttpPost]
        public IActionResult Edit_HoaDon(string id)
        {
         
            Hoadon hd = db.Hoadons.Find(id);
            return View(hd);
        }
        [HttpPost]
        public IActionResult Edit_HoaDon(Hoadon hd)
        {
            Hoadon hdd = db.Hoadons.Find(hd.Sohd);
            hdd.Ngaylaphd = hd.Ngaylaphd;
            hdd.Tenkh = hd.Tenkh;
            db.SaveChanges();
            return View();
        }
        public IActionResult Details_HoaDon(string id)
        {
            Hoadon hd = db.Hoadons.Find(id);
            return View(hd);
        }
        public IActionResult Privacy()
        {
            return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}