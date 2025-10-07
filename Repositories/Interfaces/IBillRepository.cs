using SmartPayMobileApp_Backend.Models.Entities;

namespace SmartPayMobileApp_Backend.Repositories.Interfaces
{
    public interface IBillRepository
    {
        Task<Bill> AddAsync(Bill bill);
        Task<Bill?> GetByIdAsync(int billId);
        Task<IEnumerable<Bill>> GetByConsumerNumberAsync(string consumerNumber);
        Task<IEnumerable<Bill>> GetByConsumerNumberIdAsync(int consumerNumberId);
        Task<Bill> UpdateAsync(Bill bill);
    }
}

