using ProjectManagementBack.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementBack.DAL
{
    public class BaseService<T> : IDisposable where T : BaseEntity, new()
    {
        private readonly ProjMgrContext _db;
        public BaseService(ProjMgrContext db)
        {
            this._db = db;
        }
        public void Dispose()
        {
            this._db.Dispose();
        }
        public async Task SaveAsync(bool isValid=false)
        {
            if (!isValid)
            {
                _db.Configuration.ValidateOnSaveEnabled = false;
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
            else
            {
                await _db.SaveChangesAsync();
            }
        }

        public async Task CreateAsync(T t, bool save)
        {
            _db.Set<T>().Add(t);
            if (save)
            {
                await SaveAsync();
            }
        }

        public async Task EditAsync(T t, bool save)
        {
            _db.Entry(t).State = EntityState.Modified;
            if (save)
            {
                await SaveAsync();
            }
        }

        public async Task Remove(Guid id, bool save)
        {
            T t = new T()
            {
                Id = id,
            };
            _db.Entry(t).State = EntityState.Unchanged;
            t.IsRemoved = true;
            if (save)
            {
                await SaveAsync();
            }
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().AsNoTracking().Where(m => !m.IsRemoved);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, bool asc)
        {
            if (asc)
            {
                return GetAll(predicate).OrderBy(m => m.CreateTime);
            }
            else
            {
                return GetAll(predicate).OrderByDescending(m => m.CreateTime);
            }

        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, bool asc, int pageIndex, int pageSize = 10)
        {
            return GetAll(predicate, asc).Skip(pageIndex * pageSize).Take(pageSize);
        }

        public async Task<T> GetOneAsync(Guid id)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
