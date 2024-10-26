using System;
using System.Linq.Expressions;
using MAUITest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MAUITest.Data.Repositories
{
	public class BankDetailsRepository : IRepository<BankDetailsDataModel>
	{
        private readonly AppDbContext _context;
        private readonly DbSet<BankDetailsDataModel> _dbSet;

        public BankDetailsRepository(AppDbContext context)
		{
            _context = context;
            _dbSet = context.Set<BankDetailsDataModel>();
        }

        public async Task AddAsync(BankDetailsDataModel entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(BankDetailsDataModel entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BankDetailsDataModel>> FindAsync(Expression<Func<BankDetailsDataModel, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<BankDetailsDataModel>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<BankDetailsDataModel> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(BankDetailsDataModel entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

