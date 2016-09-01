using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HappyHourBeerList.Models
{
    public class Bar
    {
        public int BarId { get; set; }
        [Display(Name = "Your business' Name")]
        public string Name { get; set; }
        [Display(Name = "Google Place Id")]
        public string GooglePlaceId { get; set; }
        [Display(Name = "Sunday Specials/Happy Hour")]
        public string SundayDiscounts { get; set; }
        [Display(Name = "Monday Specials/Happy Hour")]
        public string MondayDiscounts { get; set; }
        [Display(Name = "Tuesday Specials/Happy Hour")]
        public string TuesdayDiscounts { get; set; }
        [Display(Name = "Wednesday Specials/Happy Hour")]
        public string WednesdayDiscounts { get; set; }
        [Display(Name = "Thursday Specials/Happy Hour")]
        public string ThursdayDiscounts { get; set; }
        [Display(Name = "Friday Specials/Happy Hour")]
        public string FridayDiscounts { get; set; }
        [Display(Name = "Saturday Specials/Happy Hour")]
        public string SaturdayDiscounts { get; set; }
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