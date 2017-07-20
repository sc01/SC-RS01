using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sign.HelperClasses;
using Sign.Models;
using Sign.Models.Business;
using Sign.RepostryInterfaces;

namespace Sign.RepositoriesClasses
{
    public class MainRepostry<T> : IMainRepostry<T> where T : class 
    {
        private readonly RealStateDatabase _db;
        public MainRepostry(RealStateDatabase db)
        {
            _db = db;
        }

        public virtual async Task<bool> Add(T entity)
        {
            _db.Add(entity);
            return await SaveChanges();
        }

        public virtual Task<bool> Update(T entity)
        {

            _db.Update(entity);
            return SaveChanges();
        }
        
        public virtual Task<bool> Delete(T entity)
        {
            _db.Remove(entity);
           return SaveChanges();
           
        }

        public virtual Task<T> GetbyId(int id)
        {
         return _db.FindAsync<T>(id);
        }

        public Task<T> GetByIdUsingInclude(Expression<Func<T, bool>> expr, params Expression<Func<T, object>>[] includs)
        {
            return _db.Set<T>().IncludeMultiple(includs).SingleOrDefaultAsync(expr);
        }
        

        public virtual IEnumerable<T> GetByexpr(Func<T , bool> expr)
        {
          return  _db.Set<T>().Where(expr);
        }
        
        public virtual Task<List<T>> Getall()
        {
            return _db.Set<T>().ToListAsync();
        }


      public RealStateDatabase DircAccessToDb
      {
          get => _db;
          set => throw new NotImplementedException();
        }

        //Helper Method
       public async Task<bool> SaveChanges()
        {
            if (await _db.SaveChangesAsync() > 0)
            {
                return true;
            }
         
            return false;
        }
        
    }
}
