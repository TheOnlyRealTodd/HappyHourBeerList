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
            var address = _context.Addresses.SingleOrDefault(a => a.BarId == id);
            //Make sure that the id actually exists:
            if (bar == null)
            {
                return HttpNotFound();
            }
            var viewModel = Mapper.Map<Bar, BarFormViewModel>(bar);
            if (address == null)
            {
                address = new Address();
            }
            Mapper.Map<Address, BarFormViewModel>(address, viewModel);

            viewModel.IsNew = false;

            return View("BarForm", viewModel);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Save(BarFormViewModel bar)
        {
            
            if (!ModelState.IsValid)
            {

                bar.IsNew = false;
                return View("BarForm", bar);

            }
            if (bar.Bar.BarId == 0)
            {

                var newbar = Mapper.Map<BarFormViewModel, Bar>(bar);
                newbar.LastUpdated = DateTime.UtcNow;
                _context.Bars.Add(newbar);
                var addressToAdd = Mapper.Map<BarFormViewModel, Address>(bar);
                _context.Addresses.Add(addressToAdd);

            }
            else
            {
                var barInDb = _context.Bars.Single(b => b.BarId == bar.Bar.BarId);
                var addressInDb = _context.Addresses.Single(a => a.BarId == bar.Bar.Address.BarId);
                Mapper.Map<BarFormViewModel, Bar>(bar, barInDb);
                Mapper.Map<BarFormViewModel, Address>(bar, addressInDb);

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Bar");
        }

    }
}