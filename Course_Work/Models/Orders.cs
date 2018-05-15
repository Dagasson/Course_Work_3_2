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
        
        public Int32 UserId { get; set; }
        public User User { get; set; }

        public Int32 Sum { get; set; }
        public DateTime DateOfOrder { get; set; }
    }
}
