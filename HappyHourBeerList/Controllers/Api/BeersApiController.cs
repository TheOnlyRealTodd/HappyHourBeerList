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
    public class BeersApiController : ApiController
    {

        private ApplicationDbContext _context;

        public BeersApiController()
        {
            _context = new ApplicationDbContext();
        }
        //GET api/BeersApi
        public IHttpActionResult GetBeers(string query = null)
        {
            IQueryable<Beer> beersQuery = _context.Beers;

            if (!String.IsNullOrWhiteSpace(query))
                beersQuery = beersQuery.Where(m => m.Name.Contains(query));

            var beersDtos = beersQuery
                .ToList()
                .Select(Mapper.Map<Beer, BeerDto>);

            return Ok(beersDtos);
        }

        public IHttpActionResult GetBeer(int id)
        {
            var movie = _context.Beers.SingleOrDefault(c => c.BeerId == id);
            if (movie == null)
            {
                NotFound();
            }
            return Ok(Mapper.Map<Beer, BeerDto>(movie));
        }


        //POST api/movies
        [HttpPost]
        public IHttpActionResult CreateBeer(BeerDto beersDto)
        {
            //Validates the data sent by the client.
            if (!ModelState.IsValid)
            {
                BadRequest(); //Another REST convention here

            }
            //The below Generic literally turns MoviesDto into a movie object that can have its data put into the DB.
            var beer = Mapper.Map<BeerDto, Beer>(beersDto); //Map the data from the Dto (entry point from client) to the domain model this time.

            _context.Beers.Add(beer);
            _context.SaveChanges();
            beersDto.BeerId = beer.BeerId;
            //Creates a 201 CREATED message with the URL and received content?
            return Created(new Uri(Request.RequestUri + "/" + beer.BeerId), beersDto);
        }

        //DELETE /api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            //Selects the movie by id
            var beerInDb = _context.Beers.SingleOrDefault(b => b.BeerId == id);
            if (beerInDb == null) //If there is not matching id in the database, throw exception.
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Beers.Remove(beerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
