using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Course_Work.ViewModels
{
    public class AddToShopViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Cost")]
        public Int32 Cost { get; set; }
        [Required]
        [Display(Name = "Info")]
        public string Info { get; set; }

    }
}
