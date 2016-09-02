using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using HappyHourBeerList.Models;
using HappyHourBeerList.ViewModels;

namespace HappyHourBeerList.Controllers
{
    public class BrewerController : Controller
    {
        private ApplicationDbContext _context;

        public BrewerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Brewer
        public ActionResult Index()
        {
            var brewers = _context.Brewers.ToList();
            return View(brewers);
        }

        public ActionResult Create()
        {
            var viewModel = new BrewerFormViewModel
            {
                IsNew = true,
                Brewer = new Brewer()
            };
            viewModel.Brewer.DateAdded = DateTime.UtcNow;

            return View("BrewerForm", viewModel);
        }
        public ActionResult Details(int id)
        {
            var bar = _context.Brewers.SingleOrDefault(b => b.BrewerId == id);
            if (bar == null)
            {
                return HttpNotFound();
            }
            else
            {
                //Redirect to the Edit form
                return RedirectToAction("Edit", new { id = id });
            }
        }

        public ActionResult Edit(int id)
        {
            //Include method pulls associated bar address out of DB as well.
            var bar = _context.Brewers.SingleOrDefault(b => b.BrewerId == id);
            //Make sure that the id actually exists:
            if (bar == null)
            {
                return HttpNotFound();
            }

            var viewModel = new BrewerFormViewModel
            {
                Brewer = bar,
                IsNew = false
            };

            return View("BrewerForm", viewModel);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Save(Brewer brewer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BrewerFormViewModel()
                {
                    IsNew = false,
                    Brewer = brewer
                };
                return View("BrewerForm", viewModel);
            
            }
            if (brewer.BrewerId == 0)
            {


                brewer.LastUpdated = DateTime.UtcNow;
                brewer.DateAdded = DateTime.UtcNow;
                _context.Brewers.Add(brewer);

            }
            else
            {
                var barInDb = _context.Brewers.Single(b => b.BrewerId == brewer.BrewerId);
                Mapper.Map(brewer, barInDb);
                barInDb.LastUpdated = DateTime.UtcNow;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Brewer");
        }
    }
}