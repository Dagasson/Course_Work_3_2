using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Course_Work.Models
{
    public class Orders
    {
        [Key]
        public Int32 Id { get; set; }
        
        public String UserId { get; set; }
        public User User { get; set; }

        public Int32 ShopId { get; set; }
        public Shop Shop { get; set; }
        
        public DateTime DateOfOrder { get; set; }
        public string Adress { get; set; }
    }
}
