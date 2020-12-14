using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneFinalProject.Models
{
    public class Menu
    {
        public string MenuId { get; set; }
        [Required (ErrorMessage ="You must enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must enter a price")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string MenuCategoryId { get; set; }
        public MenuCategory Category { get; set; }
        public string MenuImageId { get; set; }
        public MenuImage Image { get; set; }
    }
}
