using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_Work.Models;
using System.ComponentModel.DataAnnotations;

namespace Course_Work.ViewModels
{
    public class OrdersViewModel
    {
        [Required]
        [Display(Name = "ShopId")]
        public Int32 ShopId { get; set; }

        [Required]
        [Display(Name = "DateOfOrder")]
        public DateTime DateOfOrder { get; set; }

        [Required]
        [Display(Name = "Adress")]
        public string Adress { get; set; }

    }
}
