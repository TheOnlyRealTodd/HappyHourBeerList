using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual Address Address { get; set; }
        public ICollection<Beer> Beers { get; set; }
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }

        public DateTime? DateAdded { get; set; }
    }
}