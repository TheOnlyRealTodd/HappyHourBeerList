using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HappyHourBeerList.Dtos;
using HappyHourBeerList.Models;
using HappyHourBeerList.ViewModels;

namespace HappyHourBeerList.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Bar, BarDto>();
            Mapper.CreateMap<BarDto, Bar>();
            Mapper.CreateMap<Beer, BeerDto>();
            Mapper.CreateMap<BeerDto, Beer>();
            Mapper.CreateMap<BarBeer, BarBeerDto>();
            Mapper.CreateMap<BarBeerDto, BarBeer>();
            Mapper.CreateMap<Bar, BarFormViewModel>();
            Mapper.CreateMap<BarFormViewModel, Bar>();
            Mapper.CreateMap<BarFormViewModel, Address>();
            Mapper.CreateMap<Address, BarFormViewModel>();
            Mapper.CreateMap<Address, BarFormViewModel>()
            .ForMember(dest => dest.AddressId, o => o.MapFrom(source => source.Id));
            Mapper.CreateMap<BarFormViewModel, Address>()
            .ForMember(dest => dest.Id, o => o.MapFrom(source => source.AddressId));
        }
    }
}