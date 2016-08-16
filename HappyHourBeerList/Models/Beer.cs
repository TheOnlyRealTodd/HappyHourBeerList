using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HappyHourBeerList.Models
{
    public class Beer
    {
        public int BeerId { get; set; }

        [Display(Name = "Beer Name (Required)")]
        public string Name { get; set; }
        [Display(Name = "International Bitterness Units (IBUs)")]
        [IbuLimitations]
        public byte? Ibu { get; set; }
        [Display(Name = "Alcohol by volume percentage")]
        public decimal Abv { get; set; }

        [Display(Name = "Brewer (Required)")]
        public string Brewer { get; set; }
        public string Description { get; set; }
        [Display(Name = "URL to Logo (Optional)")]
        public string LogoPath { get; set; }

        public DateTime DateAdded { get; set; }

        public ICollection<Bar> Bars { get; set; }
    }
}