using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course_Work.Models;
using Course_Work.Context;
using Microsoft.EntityFrameworkCore;

namespace Course_Work.Repository
{
    public class UserRepository : IRepository<User>
    {
        public readonly dbcontext db;
        public IEnumerable<User> GetAll => throw new NotImplementedException();

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(int? id)
        {
            User user = (User)db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }

        }

        public void Edit(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public User Get(int id)
        {
            return (User)db.Users.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
