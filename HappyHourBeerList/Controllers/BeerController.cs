using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappyHourBeerList.Models;

namespace HappyHourBeerList.Controllers
{
    public class BeerController : Controller
    {
        private ApplicationDbContext _context;

        public BeerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Beer
        public ActionResult Index()
        {
            var beers = _context.Beers.Include("Bars").ToList();

            return View();
        }
    }
}