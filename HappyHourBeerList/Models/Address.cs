using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HappyHourBeerList.Models
{
    public class Address
    {
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Must be a number")]
        [Display(Name = "Street Number")]
        public int? Number { get; set; }
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }
        
        public string City { get; set; }

        public string State { get; set; }
        [Display(Name = "ZIP Code")]
        public int ZipCode { get; set; }

        public virtual Bar Bar { get; set; }
        [Key]
        [ForeignKey("Bar")]
        public int BarId { get; set; }
    }
}