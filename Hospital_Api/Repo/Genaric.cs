using Microsoft.EntityFrameworkCore;
using Hospital_Api.Data;

namespace Hospital_Api.Repo
{
    public class Genaric<T> : IGenaric<T> where T : class
    {
        protected App_DbContext _db;

        public Genaric(App_DbContext db)
        {
            _db = db;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public virtual async Task Add(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _db.Set<T>().FindAsync(id);
            if(entity == null)
            {
                return false;
            }
            _db.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        
    }
}
