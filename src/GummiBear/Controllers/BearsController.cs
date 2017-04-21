using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummiBear.Models;

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
    }
}
