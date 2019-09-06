using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

using System.Web.Mvc;
using NLog;

namespace ItuneSystem.Controllers
{
    public class HomeController : Controller
    {
        private Itune_SystemEntities db = new Itune_SystemEntities();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public ActionResult Index()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    logger.Info("Model State is Correct");
                }
            }
             catch (DataException /* dex */)
            {
                logger.Info("There is an error message");

            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult BoughtSongsByUser()
        {

           var result = db.Database.SqlQuery<boughtSongsByUser>("EXEC BoughtSongsByUsers").ToList();
           return View(result);
        }
        public class boughtSongsByUser
        {
            public int UsersId { get; set; }
            public string Name { get; set; }
            public string Song { get; set; }
        }
        public ActionResult NumberOfSongsBought()
        {

            var result = db.Database.SqlQuery<numberSongsBoughtByUser>("EXEC NumberofSongsByUsers").ToList();
            return View(result);
        }
        public class numberSongsBoughtByUser
        {
    
            public string NumberOfSales { get; set; }
            public string Song { get; set; }
        }
    }
}