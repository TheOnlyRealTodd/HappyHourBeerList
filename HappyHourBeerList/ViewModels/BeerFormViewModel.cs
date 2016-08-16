using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HappyHourBeerList.Models;

namespace HappyHourBeerList.ViewModels
{
    
    public class BeerFormViewModel
    {

        public Beer Beer { get; set; }
        public bool IsNew { get; set; }
    }
}