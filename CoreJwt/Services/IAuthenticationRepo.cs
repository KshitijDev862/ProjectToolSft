 using System.Collections.Generic;
 using System.Threading.Tasks;
 using System;

 namespace CoreJwt.Services {
     public interface IAuthenticationRepo {
         void Add<T> (T entity) where T : class;
         void Delete<T> (T entity) where T : class;
         Task<bool> SaveAll ();
     }
 }