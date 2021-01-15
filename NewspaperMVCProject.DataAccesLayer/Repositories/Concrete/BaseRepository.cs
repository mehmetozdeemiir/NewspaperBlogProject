using NewspaperMVCProject.DataAccesLayer.Context;
using NewspaperMVCProject.DataAccesLayer.Repositories.Interfaces;
using NewspaperMVCProject.EntityLayer.Entities.Concrete;
using NewspaperMVCProject.EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperMVCProject.DataAccesLayer.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ProjectContext _context;
        public BaseRepository() => _context = new ProjectContext();
        

        public void Add(T item)
        {
           
            _context.Set<T>().Add(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);
        
        public List<T> GetActive() => _context.Set<T>().Where(x => x.Status != Status.Passive).ToList();


        public List<T> GetAll() => _context.Set<T>().ToList();

        public T GetByDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).FirstOrDefault();


        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);    //farklı retrun kullanımı
        }


        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }


        public void Remove(int id)
        {
            T item = GetById(id);
            item.Status = Status.Passive;
            item.PassiveDate = DateTime.Now;
            Save();
        }

        public int Save() => _context.SaveChanges();

        public void Update(T item)
        {
            T updatedItem = GetById(item.Id);
            DbEntityEntry dbEntityEntry = _context.Entry(updatedItem);
            dbEntityEntry.CurrentValues.SetValues(item);
            Save();
        }
    }
}
