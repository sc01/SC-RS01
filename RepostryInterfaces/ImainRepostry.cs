using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Sign.Models;
using Sign.Models.Business;

namespace Sign.RepostryInterfaces
{
   public interface IMainRepostry<T>
   {
       Task<bool> Add(T entity);


       Task<bool> Update(T entity);


       Task<bool> Delete(T entity);


       Task<T> GetbyId(int id);

      Task<T> GetByIdUsingInclude( Expression<Func<T, bool>> expr , params Expression<Func<T, Object>>[] includs);

       IEnumerable<T> GetByexpr(Func<T, bool> expr);

       Task<List<T>> Getall();
       
         RealStateDatabase DircAccessToDb { get; set; }

        //Helper Method
       Task<bool> SaveChanges();


   }
}
