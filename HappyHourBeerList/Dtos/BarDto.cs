using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HappyHourBeerList.Models;

namespace HappyHourBeerList.Dtos
{
    public class BarDto
    {
        public int BarId { get; set; }
        public string Name { get; set; }
        [Required]
        public string GooglePlaceId { get; set; }
        public string SundayDiscounts { get; set; }
        public string MondayDiscounts { get; set; }
        public string TuesdayDiscounts { get; set; }
        public string WednesdayDiscounts { get; set; }
        public string ThursdayDiscounts { get; set; }
        public string FridayDiscounts { get; set; }
        public string SaturdayDiscounts { get; set; }
        public virtual Address Address { get; set; }
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }
    }
}