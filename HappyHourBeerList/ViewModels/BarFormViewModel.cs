using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HappyHourBeerList.Models;
using AutoMapper;

namespace HappyHourBeerList.ViewModels
{
    public class BarFormViewModel
    {
        public Address Address { get; set; }
        public Bar Bar { get; set; }

        public bool IsNew { get; set; }


    }
}