using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Course_Work.Models
{
    public class Shop
    {
        [Key]
        public Int32 Id { get; set; }

        public string Name { get; set; }
        public Int32 Cost { get; set; }
        public string Info { get; set; }

    }
}
