using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
     
        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
           
        }

        public IActionResult Index()
        {
            var list = db.Conferences.Select(x => x).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            
            return this.View();
        }
        [HttpPost]
        public IActionResult Create(Conference conf,string[] file)
        {
            conf.User = HttpContext.User.Identity.Name;
            db.Conferences.Add(conf);

            db.SaveChanges();
            return this.RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = db.Conferences.FirstOrDefault(x => x.Id == id);
            return View(edit);
        }

        [HttpPost]
        public IActionResult Edit(Conference check)
        {
            var toedit = db.Conferences.FirstOrDefault(x => x.Id == check.Id);
            toedit.ConferenceName = check.ConferenceName;
            toedit.Duration = check.Duration;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var todel = db.Conferences.FirstOrDefault(x => x.Id == id);
            return View(todel);
        }

        [HttpPost]
        public IActionResult Delete(Conference check)
        {
           var todel = db.Conferences.FirstOrDefault(x => x.Id == check.Id);
            db.Conferences.Remove(todel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Event(int id)
        {
            var toDisplay = db.Conferences.FirstOrDefault(x => x.Id == id);
            return View(toDisplay);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

