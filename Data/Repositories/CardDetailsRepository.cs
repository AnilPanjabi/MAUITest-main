using System;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MAUITest.Data.Models;

namespace MAUITest.Data.Repositories
{
	public class CardDetailsRepository : IRepository<CardDetailsDataModel>
    {
        private readonly AppDbContext _context;
        private readonly DbSet<CardDetailsDataModel> _dbSet;

        public CardDetailsRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<CardDetailsDataModel>();
        }

        public async Task AddAsync(CardDetailsDataModel entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CardDetailsDataModel entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CardDetailsDataModel>> FindAsync(Expression<Func<CardDetailsDataModel, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<CardDetailsDataModel>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<CardDetailsDataModel> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(CardDetailsDataModel entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

