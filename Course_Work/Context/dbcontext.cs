using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Course_Work.Models;
using Microsoft.EntityFrameworkCore;

namespace Course_Work.Context
{
    public class dbcontext : IdentityDbContext<User>
    {
        public DbSet<Orders> Order {get; set;}
        public DbSet<productOnOrder> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }

        public dbcontext(DbContextOptions<dbcontext> options):base(options)
        {       
        }
    }
    
}
