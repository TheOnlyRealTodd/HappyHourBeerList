using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HappyHourBeerList.Models
{
    public class Brewer
    {
        //Still need to add Brewer into Beer class, One-to-Many Brewer:Beers
        public int BrewerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }

        //Address Information BEGIN:
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Must be a number")]
        [Display(Name = "Street Number")]
        public int? Number { get; set; }
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        [Display(Name = "ZIP Code")]
        public int ZipCode { get; set; }
        //Address Information END
        public ICollection<Beer> Beers { get; set; }
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }

        public DateTime? DateAdded { get; set; }
    }
}