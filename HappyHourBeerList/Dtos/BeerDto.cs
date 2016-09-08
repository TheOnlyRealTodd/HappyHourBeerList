using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HappyHourBeerList.Models;

namespace HappyHourBeerList.Dtos
{
    public class BeerDto
    {
        public int BeerId { get; set; }
        [Required]

        public string Name { get; set; }
        [IbuLimitations]
        public byte? Ibu { get; set; }
       
        public decimal Abv { get; set; }
        [Required]
        public string Brewer { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
        public DateTime DateAdded { get; set; }
        public ICollection<Bar> Bars { get; set; }
    }
}