using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HappyHourBeerList.Models;

namespace HappyHourBeerList.Dtos
{
    public class BarBeerDto
    {
        public int Id { get; set; }
        public Bar Bar { get; set; }
        public int BarId { get; set; }
        public Beer Beer { get; set; }
        public int BeerId { get; set; }
    }
}