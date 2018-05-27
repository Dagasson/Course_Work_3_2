using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_Work.Models;

namespace Course_Work.ViewModels
{
    public class UserInfoViewModel
    {
        public User User { get; set; }
        public List<Orders> Orders { get; set; }
        public List<Shop> Shops { get; set; }

        public List<forview> fview { get; set; }

        public class forview
        {
            public String Name { get; set; }
            public DateTime DateOfOrder { get; set; }
            public string Adress { get; set; }
            
        }
        
    }
}
