using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AtmProject.Models;
using AtmProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using AtmProject.Extenssions;
using AtmProject.Models.ModelView;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Globalization;

namespace AtmProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataBase db;
        IWebHostEnvironment env;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            this.db = new DataBase();
            _logger = logger;
            this.env = env;
        }

        public IActionResult Index()
        {
            db.Database.EnsureCreated();
            return View();
        }

        [HttpPost]
        public IActionResult Import(IFormFile postedFile)
        {
            var reader = System.IO.File.ReadAllLines(@"C:\Users\dimit\Desktop\Files\Files\ATMs.csv");

            return RedirectToAction("Index");
        }

        //Prices functionality and View
        public IActionResult AtmConfig()
        {

            var list = db.Atms.ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult AtmConfigAction(Atm atm)
        {
            db.Atms.Add(atm);
            db.SaveChanges();
            return RedirectToAction("AtmConfig");
        }

        //Prices functionality and View
        public IActionResult PricesConfig()
        {
            var list = db.Prices.ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult PricesConfigAction(Prices price)
        {
            db.Prices.Add(price);
            db.SaveChanges();
            return RedirectToAction("PricesConfig");
        }


        //-------------------------------------------------------------------
        [HttpPost]
        public IActionResult OnPostUpload(IFormFile file)
        {
            var filepath = env.WebRootPath;
            if (file == null) return RedirectToAction("Index");
            using (var stream = System.IO.File.Create(filepath + @$"\Uploads\{file.FileName}"))
            {
                file.CopyTo(stream);
            }
            CsvReader.AddToAtmDataBase(filepath + @$"\Uploads\{file.FileName}");

            System.IO.File.Delete(filepath + @$"\Uploads\{file.FileName}");

            return Ok(new { filepath });

        }

        [HttpPost]
        public async Task<IActionResult> OnPostUploadHistory(string id, IFormFile file)
        {
            var filepath = env.WebRootPath;

            //if (file == null) return RedirectToAction("Index");

            using (var stream = System.IO.File.Create(filepath + @$"\Uploads\{file.FileName}"))
            {
                await file.CopyToAsync(stream);
            }
            CsvReader.AddToHistoricDataBase(filepath + @$"\Uploads\{file.FileName}", id);

            System.IO.File.Delete(filepath + @$"\Uploads\{file.FileName}");

            return RedirectToAction("AtmConfig");

        }

        #region Chart function
        /// <summary>
        /// Load data for the chart
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult PreviousLoadChart()
        {
            var temp = new List<JsonModel>();
            var populationList = db.HistoricData.ToList();

            foreach (var item in populationList)
            {
                var j = new JsonModel() { y = item.PreviousWithdraw, x = item.PreviousLoad };
                temp.Add(j);
            }
            temp.Sort((x, y) => x.x.CompareTo(y.x));
            return Json(data: temp);
        }

        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
