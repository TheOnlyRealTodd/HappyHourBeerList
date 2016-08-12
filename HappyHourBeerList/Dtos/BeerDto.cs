using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HappyHourBeerList.Dtos
{
    public class BeerDto
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        
        public byte Ibu { get; set; }
       
        public decimal Abv { get; set; }
        [Required]
        public string Brewer { get; set; }
        public string Description { get; set; }
        public string LogoPath { get; set; }
    }
}