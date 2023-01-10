using KD12NTierApp.Core.DataAccess.Abstract;
using KD12NTierApp.Core.Entities.Abstract;
using KD12NTierApp.Core.Enums;
using KD12NTierApp.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD12NTierApp.DataAccess.EntityFramework.Concrete
{
    public class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly KD12NTierAppDbContext _kD12NTierAppDbContext;
        private DbSet<T> _table;

        public BaseRepository(KD12NTierAppDbContext kD12NTierAppDbContext)
        {
            _kD12NTierAppDbContext = kD12NTierAppDbContext;
            _table = _kD12NTierAppDbContext.Set<T>();
        }
        public async Task<bool> Add(T entity)
        {
            await _table.AddAsync(entity);
            return await Save() > 0;
        }

        public async Task<bool> AddRange(List<T> entities)
        {
            await _table.AddRangeAsync(entities);
            return await Save() > 0;
        }

        public async Task<bool> Delete(T entity)
        {
            entity.GetType().GetProperty("Status").SetValue(entity, Status.Passive);
            return await Update(entity);
        }

        public async Task<List<T>> GetAll() => await _table.ToListAsync();

        public async Task<T> GetById(int id) => await _table.FindAsync(id);

        public async Task<int> Save()
        {
            return await _kD12NTierAppDbContext.SaveChangesAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _kD12NTierAppDbContext.Entry<T>(entity).State = EntityState.Modified;
            return await Save() > 0;
        }
    }
}
