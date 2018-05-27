using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_Work.Models;
using Course_Work.Context;
using Microsoft.EntityFrameworkCore;

namespace Course_Work.Repository
{
    public class OrdersRepository : IRepository<Orders>
    {
        private readonly dbcontext db;
        public IEnumerable<Orders> GetAll => db.Order;

        public OrdersRepository(dbcontext model)
        {
            db = model;
        }

        public void Create(Orders item)
        {
            db.Order.Add(item);
        }

        public void Delete(int? id)
        {
            Orders result = db.Order.Find(id);
            if (result != null)
            {
                db.Order.Remove(result);
            }
        }

        public void Edit(Orders item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Orders Get(int id)
        {
            return db.Order.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}