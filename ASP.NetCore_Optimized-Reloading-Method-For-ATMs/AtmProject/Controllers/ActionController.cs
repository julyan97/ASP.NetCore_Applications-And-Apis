using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtmProject.Data;
using AtmProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtmProject.Controllers
{
    public class ActionController : Controller
    {
        private DataBase db;
        IWebHostEnvironment env;

        public ActionController(IWebHostEnvironment env)
        {
            this.db = new DataBase();
            this.env = env;
        }
        //Actions
            //Atm
        [HttpPost]
        public async Task<IActionResult> DeleteAtm(string id)
        {
            var todel = await db.Atms.Include(x=>x.HD).FirstOrDefaultAsync(x => x.TID == id);
            db.Atms.Remove(todel);
            await db.SaveChangesAsync();
            return RedirectToAction("AtmConfig",controllerName: "Home");
        }
                
        [HttpPost]
        public IActionResult UpdateAtm(Atm atm)
        {
            var toUpdate = db.Atms.FirstOrDefault(x => x.TID == atm.TID);
            if (toUpdate == null) return RedirectToAction("Index");
            toUpdate.Update(atm);
            db.SaveChanges();
            return RedirectToAction("AtmConfig", controllerName: "Home");
        }
        public IActionResult UpdateAtm(string id)
        {
            var toUpdate = db.Atms.FirstOrDefault(x => x.TID == id);
            return View(toUpdate);
        }
        
        //
        [HttpPost]
        public IActionResult Delete(string id)
        { 
            var todel = db.Prices.FirstOrDefault(x => x.ID == id);
            db.Prices.Remove(todel);
            db.SaveChanges();
            return RedirectToAction("PricesConfig",controllerName:"Home");
        }

        [HttpPost]
        public IActionResult Update(Prices price)
        {
            var toUpdate = db.Prices.FirstOrDefault(x => x.ID == price.ID);
            toUpdate.Update(price);
            db.SaveChanges();
            return RedirectToAction("PricesConfig", controllerName: "Home");
        }

        public IActionResult Update(string id)
        {
            var toUpdate = db.Prices.FirstOrDefault(x => x.ID == id);
            return View(toUpdate);
        }
    }
}