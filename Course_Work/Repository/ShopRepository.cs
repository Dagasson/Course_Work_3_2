using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_Work.Models;
using Course_Work.Context;
using Microsoft.EntityFrameworkCore;

namespace Course_Work.Repository
{
    public class ShopRepository : IRepository<Shop>
    {
        private readonly dbcontext db;
        public IEnumerable<Shop> GetAll => db.Shops;

        public void Create(Shop item)
        {
            db.Shops.Add(item);
        }

        public void Delete(int? id)
        {
            Shop result = db.Shops.Find(id);
            if (result != null)
            {
                db.Shops.Remove(result);
            }
        }

        public void Edit(Shop item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Shop Get(int id)
        {
            return db.Shops.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}