using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using HappyHourBeerList.Dtos;
using HappyHourBeerList.Models;

namespace HappyHourBeerList.Controllers.Api
{
    public class BarsApiController : ApiController
    {
        private ApplicationDbContext _context;

        public BarsApiController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/bars
        public IHttpActionResult GetBars()
        {
            var barDtos = _context.Bars.ToList().Select(Mapper.Map<Bar, BarDto>);
            return Ok(barDtos);
        }

        //GET /api/bars/id#
        public IHttpActionResult GetBar(int id)
        {
            var bar = _context.Bars.SingleOrDefault(b => b.BarId == id);
            if (bar == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Bar, BarDto>(bar));
        }

        //POST /api/bars
        [HttpPost]
        public IHttpActionResult CreateBar(BarDto barDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            var bar = Mapper.Map<BarDto, Bar>(barDto);
            bar.LastUpdated = DateTime.UtcNow;
            _context.Bars.Add(bar);
            _context.SaveChanges();
            barDto.Bar.BarId = bar.BarId;
            return Created(new Uri(Request.RequestUri + "/" + bar.BarId), barDto);
        }

        //PUT /api/bars/id#
        [HttpPut]
        public IHttpActionResult UpdateBar(int id, BarDto barDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var barInDb = _context.Bars.SingleOrDefault(b => b.BarId == id);
            if (barInDb == null)
            {
                return NotFound();
            }
            Mapper.Map<BarDto, Bar>(barDto, barInDb);
            barInDb.LastUpdated = DateTime.UtcNow;

            _context.SaveChanges();
            return Ok();


        }

    }
}
