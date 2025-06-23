using AquiTourism.Application.ViewModel;
using AquiTourism.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
           CreateMap<Attraction, AttractionViewModel>().ReverseMap();
            CreateMap<Operator, OperatorViewModel>().ReverseMap();
        }
    }
}
