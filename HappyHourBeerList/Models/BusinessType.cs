using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HappyHourBeerList.Models
{
    public class BusinessType
    {
        public byte BusinessTypeId { get; set; }
        public string Name { get; set; }
    }
}