using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBear.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GummiBear.Controllers
{
    public class BearsController : Controller
    {
        // GET: /<controller>/
        private GummiBearDbContext db = new GummiBearDbContext();
        public IActionResult Index()
        {
            return View(db.Bears.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisBear = db.Bears.FirstOrDefault(bears => bears.BearId == id);
            return View(thisBear);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Bear bear)
        {
            db.Bears.Add(bear);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisBear = db.Bears.FirstOrDefault(items => items.BearId == id);
            return View(thisBear);
        }

        [HttpPost]
        public IActionResult Edit(Bear bear)
        {
            db.Entry(bear).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisBear = db.Bears.FirstOrDefault(bears => bears.BearId == id);
            return View(thisBear);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisBear = db.Bears.FirstOrDefault(bears => bears.BearId == id);
            db.Bears.Remove(thisBear);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
