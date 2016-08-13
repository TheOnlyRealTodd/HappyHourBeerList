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
            
            var bar = _context.Bars.SingleOrDefault(m => m.BarId == id);
            //Make sure that the id actually exists:
            if (bar == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<Bar, BarFormViewModel>(bar);

            viewModel.IsNew = false;

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
                var addressToAdd = bar.Address;
                _context.Addresses.Add(addressToAdd);

            }
            else
            {
                var barInDb = _context.Bars.Single(b => b.BarId == bar.BarId);
             //   var addressInDb = _context.Addresses.Single(a => a.BarId == bar.Bar.Address.BarId);
                barInDb = bar;
                barInDb.LastUpdated = DateTime.UtcNow;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Bar");
        }

    }
}