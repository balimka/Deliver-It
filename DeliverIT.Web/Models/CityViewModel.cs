using DeliverIT.Services.DTOs;
using DeliverIT.Web.Models.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeliverIT.Web.Models
{
    public class CityViewModel : ISearchable
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Value for {0} must be between {2} and {1}.")]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        public List<SelectListItem> Countries { get; set; } = new List<SelectListItem>();

        public IEnumerable<CityDTO> Cities { get; set; } = new List<CityDTO>();

        public string FilterTag { get; set; }
    }
}
