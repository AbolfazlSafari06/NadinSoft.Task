using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using NadinSoft.Domain.IRepositories;
using NadinSoft.Infrastructure.EFContext; 

namespace NadinSoft.Infrastructure.Repositories;

public class BaseRepository<TId, T> : IBaseRepository<TId, T> where T : class
{
    private readonly NadinSoftContext _context;

    public BaseRepository(NadinSoftContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetListAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> query)
    {
        return await _context.Set<T>().AsNoTracking().Where(query).ToListAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> query)
    {
        return await _context.Set<T>().AnyAsync(query);
    }

    public async Task<T?> GetByIdAsync(TId id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> CreateAsync(T command)
    {
        await _context.Set<T>().AddAsync(command);
        await SaveChangesAsync();
        return command;
    }
     
    public async Task RemoveByIdAsync(T command)
    {
        _context.Set<T>().Remove(command);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}