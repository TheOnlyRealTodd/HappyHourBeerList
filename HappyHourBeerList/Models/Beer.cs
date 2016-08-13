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
        [Required]
        [Display(Name = "Beer Name")]
        public string Name { get; set; }
        [Display(Name = "International Bitterness Units (IBUs)")]
        public byte Ibu { get; set; }
        [Display(Name = "Alcohol by volume percentage")]
        public decimal Abv { get; set; }
        [Required]
        public string Brewer { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
    }
}