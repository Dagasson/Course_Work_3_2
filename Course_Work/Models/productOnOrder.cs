using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Course_Work.Models
{
    public class productOnOrder
    {
        [Key]
        public Int32 Id { get; set; }

        public Int32 OrdersId { get; set; }
        public Orders Orders { get; set; }

        public Int32 ShopId { get; set; }
        public Shop Shop { get; set; }
        
    }
}
