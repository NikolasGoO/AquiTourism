using AquiTourism.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Application.ViewModel
{
    public class AttractionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public List<string> ImagesUrl { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo tipo é obrigatório")]
        public TypeAttraction Type { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo descrição curta é obrigatório")]
        public string ShortDescription { get; set; }
        public string? Slogan { get; set; }
        [Required(ErrorMessage = "O campo Preços é obrigatório")]
        public decimal Price { get; set; }
        public string? Schedules { get; set; }
        public string? Address { get; set; }
        public string Link { get; set; }
    }
}
