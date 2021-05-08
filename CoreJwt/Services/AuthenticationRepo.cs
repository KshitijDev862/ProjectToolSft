using System.Threading.Tasks;

namespace CoreJwt.Services
{
    public class AuthenticationRepo:IAuthenticationRepo
    {
          private readonly StoreContext _context;
           public AuthenticationRepo (StoreContext context) {
            _context = context;
        }
         public void Add<T> (T entity) where T : class {
            _context.Add (entity);
        }

        public void Delete<T> (T entity) where T : class {
            _context.Remove (entity);
        }
        public async Task<bool> SaveAll () {
            return await _context.SaveChangesAsync () > 0;
        }

    }
}