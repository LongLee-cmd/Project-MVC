using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLySinhVien_Database_First.Models;
using QuanLySinhVien_Database_First.Mymodel;
using System.ComponentModel;

namespace QuanLySinhVien_Database_First.Controllers
{
    public class HocVienController : Controller
    {
        private qlhvContext db = new qlhvContext();
        public IActionResult Index()
        {
            //List<Lylich> ds = db.LyLich.ToList();
            //foreach(var item in ds)
            //{
            //    item.MalopNavigation =db.Lops.Find(item.Malop);
            //}
            //return View(ds);
            List<CHocVien> ds = db.LyLich.Select(x => CHocVien.chuyendoi(x)).ToList();
            foreach (var item in ds)
            {
                item.MalopNavigation = db.Lops.Find(item.Malop);
            }
            return View(ds);
        }
        public IActionResult FormThemHV()
        {
            ViewBag.DSLop=new SelectList(db.Lops.ToList(),"Malop","Tenlop");
            return View();
        }
        public IActionResult ThemHV(CHocVien x)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.LyLich.Add(CHocVien.chuyendoi(x));
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (Exception)
                {
                    ModelState.AddModelError(" ", "Đã tồn tại Học Viên!");
                }
              
            }
            ViewBag.DSLop = new SelectList(db.Lops.ToList(), "Malop", "Tenlop");
            return View("FormThemHV");


        }
        public IActionResult formXoaHV(string id)
        {
            int dem=db.Diemthis.Count(t=>t.Mshv==id);
            ViewBag.flag = true;
            if (dem > 0)
            {
                ViewBag.flag = false;
            }
            Lylich ls = db.LyLich.Find(id);
             return View(CHocVien.chuyendoi(ls)); 
        }
        public IActionResult XoaHV(string mshv)
        {
        
            try
            {
                Lylich ls = db.LyLich.Find(mshv);
                db.LyLich.Remove(ls);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception) { 
            
           
            }
            ErrorViewModel err = new ErrorViewModel();
            err.RequestId = "Không Thể Xóa Học Viên Này!";
            return View("Error",err);
        }
        public IActionResult FormSuaHV(string id)
        {
            ViewBag.DSLop = new SelectList(db.Lops.ToList(), "Malop", "Tenlop");
            Lylich ls = db.LyLich.Find(id);
            return View(CHocVien.chuyendoi(ls));
        }
        public IActionResult SuaHV(string mshv)
        {
            Lylich ls = db.LyLich.Find(mshv);
            db.LyLich.Update(ls);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult xemLop ( string id  )
        {
            Lop x = db.Lops.Find(id);
            return PartialView(x);
        }

    }

}
