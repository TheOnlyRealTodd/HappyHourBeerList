using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappyHourBeerList.Models;
using HappyHourBeerList.ViewModels;
using AutoMapper;

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

            return View(beers);
        }

        public ActionResult Create()
        {
            var viewModel = new BeerFormViewModel
            {
                IsNew = true,
                Beer = new Beer()
            };
            viewModel.Beer.DateAdded = DateTime.UtcNow;

            return View("BeerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var beer = _context.Beers.SingleOrDefault(b => b.BeerId == id);
            if (beer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new BeerFormViewModel()
            {
                Beer = beer
            };
            return View("BeerForm", viewModel);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Save(Beer beer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BeerFormViewModel()
                {
                    Beer = beer,
                    IsNew = false,
                    
                };
                return View("BeerForm", viewModel);
            }
            if (beer.BeerId == 0)
            {
                beer.DateAdded = DateTime.UtcNow;
                _context.Beers.Add(beer);
            }
            else
            {
                var beerInDb = _context.Beers.SingleOrDefault(b => b.BeerId == beer.BeerId);
                var dateAdded = beerInDb.DateAdded;
                Mapper.Map(beer, beerInDb);
                beerInDb.DateAdded = dateAdded;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Beer");
        }
    }
}