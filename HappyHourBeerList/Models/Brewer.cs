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
        public virtual Address Address { get; set; }
        public ICollection<Beer> Beers { get; set; }
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }

        public DateTime? DateAdded { get; set; }
        public BusinessType BusinessType { get; set; }
        [ForeignKey("BusinessType")]
        public byte BusinessTypeId { get; set; }
    }
}