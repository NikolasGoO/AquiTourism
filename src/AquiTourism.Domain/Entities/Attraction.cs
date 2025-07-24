using AquiTourism.Core.DomainObjects;
using AquiTourism.Core.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Domain.Entities
{
    public class Attraction : Entity
    {
        public List<string> ImagesUrl { get; set; }
        public string Name { get; set; }
        public TypeAttraction Type { get; set; }
        public string? Slogan { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }
        public string? Schedules { get; set; }
        public string? Address { get; set; }
        public string Link { get; set; }
        public int CreatedByUserId { get; set; }
        public int? DeactivatedByUserId { get; set; }
        public int? UpdatedByUserId { get; set; }
    }
}
