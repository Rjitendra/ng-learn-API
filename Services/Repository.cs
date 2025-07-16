

using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Entities;

namespace Services
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _set;

        public Repository(AppDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public event Action<T>? ItemAdded;

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _set.ToListAsync();

        public async Task<T?> GetByIdAsync(int id) =>
            await _set.FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            _set.Add(entity);
            await _context.SaveChangesAsync();
            ItemAdded?.Invoke(entity);
            return entity;
        }

        public async Task<T?> UpdateAsync(int id, T entity)
        {
            var existing = await _set.FindAsync(id);
            if (existing == null) return null;

            existing.JsonDoc = entity.JsonDoc;
            existing.UpdatedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _set.FindAsync(id);
            if (existing == null) return false;

            _set.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}