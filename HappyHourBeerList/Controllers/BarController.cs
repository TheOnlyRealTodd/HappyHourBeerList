using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using HappyHourBeerList.Dtos;
using HappyHourBeerList.Models;
using HappyHourBeerList.ViewModels;

namespace HappyHourBeerList.Controllers
{
    public class BarController : Controller
    {

        private ApplicationDbContext _context;

        public BarController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Bar
        public ActionResult Index()
        {
            var bars = _context.Bars.ToList();
            return View(bars);
        }
        public ActionResult Details(int id)
        {
            var bar = _context.Bars.SingleOrDefault(b => b.BarId == id);
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
            var bar = _context.Bars.Include("Address").SingleOrDefault(b => b.BarId == id);
            //Make sure that the id actually exists:
            if (bar == null)
            {
                return HttpNotFound();
            }

            if (bar.Address == null)
            {
                bar.Address = new Address();
            }

            var viewModel = new BarFormViewModel
            {
                Address = bar.Address,
                Bar = bar,
                IsNew = false
            };

            return View("BarForm", viewModel);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Save(Bar bar)
        { 
            if (!ModelState.IsValid)
            {
                var viewModel = Mapper.Map<Bar, BarFormViewModel>(bar);
                viewModel.IsNew = false;
                return View("BarForm", viewModel);

            }
            if (bar.BarId == 0)
            {

                
                bar.LastUpdated = DateTime.UtcNow;
                _context.Bars.Add(bar);

            }
            else
            {
                var barInDb = _context.Bars.Include("Address").Single(b => b.BarId == bar.BarId);
                Mapper.Map(bar, barInDb);
                barInDb.MondayDiscounts = bar.MondayDiscounts;
                barInDb.LastUpdated = DateTime.UtcNow;
                barInDb.Address = bar.Address;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Bar");
        }

    }
}