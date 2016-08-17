using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHourBeerList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

    //    public ActionResult GetVideo()
    //    {
    //        var videoPath =
    //           Request.MapPath("~/Views/Home/images/beer.mp4");
    //        FileStream fs =
    //           new FileStream(videoPath, FileMode.Open);
    //        return new FileStreamResult(fs, "video/mp4");
    //    }
    }
}