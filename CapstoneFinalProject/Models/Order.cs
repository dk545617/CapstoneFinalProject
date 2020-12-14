using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneFinalProject.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessage = "You must enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must enter the first address line")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "You must enter a city name")]
        public string City { get; set; }
        [Required(ErrorMessage = "You must enter a state name")]
        public string State { get; set; }
        
        public string Zip { get; set; }

        [Required(ErrorMessage = "You must enter a country name")]
        public string Country { get; set; }
    }
}
