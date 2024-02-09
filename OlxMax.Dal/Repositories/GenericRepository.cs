using Microsoft.EntityFrameworkCore;

using OlxMax.Dal.DbContexts;
using OlxMax.Dal.Entity;
using OlxMax.Dal.Repositories;

public class GenericRepository<T> : IGenericRepository<T>, IDisposable
    where T : BaseEntity
{
    protected readonly DbContexOnStartUpCreation _context;

    protected readonly DbSet<T> _table;

    public GenericRepository(DbContexOnStartUpCreation context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    public virtual async Task<T>? GetByIdAsync(int id)
    {
        var result  = await _table.FirstOrDefaultAsync(g => g.Id == id);
        return result!;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _table.ToListAsync();
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        var added = await _table.AddAsync(entity);

        await _context.SaveChangesAsync();

        return added.Entity;
    }

    public virtual async Task<T> UpdateAsync(int id, T entity)
    {
        var dbEntity = await GetByIdAsync(id)!;

        if (dbEntity is not null)
        {
            entity.Id = dbEntity.Id;
            _context.Entry(dbEntity).CurrentValues.SetValues(entity);
        }

        await _context.SaveChangesAsync();

        return dbEntity!;
    }

    public virtual async Task<T>? DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id)!;

        if (entity is null)
        {
            return null!;
        }

        _table.Remove(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public virtual async void Dispose()
    {
        await _context.DisposeAsync();
        GC.SuppressFinalize(this);
    }
}