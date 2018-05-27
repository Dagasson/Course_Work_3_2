using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_Work.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll { get; }
        T Get(int id);
        void Create(T item);
        void Edit(T item);
        void Delete(int? id);
        void Save();
    }
}