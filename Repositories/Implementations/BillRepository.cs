using Microsoft.EntityFrameworkCore;
using SmartPayMobileApp_Backend.Data;
using SmartPayMobileApp_Backend.Models.Entities;
using SmartPayMobileApp_Backend.Repositories.Interfaces;

namespace SmartPayMobileApp_Backend.Repositories.Implementations
{
    public class BillRepository : IBillRepository
    {
        private readonly ApplicationDbContext _context;

        public BillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Bill> AddAsync(Bill bill)
        {
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<Bill?> GetByIdAsync(int billId)
        {
            return await _context.Bills.FirstOrDefaultAsync(b => b.BillId == billId);
        }

        public async Task<IEnumerable<Bill>> GetByUserIdAsync(int userId)
        {
            return await _context.Bills.Where(b => b.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Bill>> GetByConsumerNumberAsync(string consumerNumber)
        {
            return await _context.Bills
                .Include(b => b.User)
                .Where(b => b.User != null && b.User.ConsumerNumber == consumerNumber)
                .ToListAsync();
        }

        public async Task<Bill> UpdateAsync(Bill bill)
        {
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();
            return bill;
        }
    }
}

