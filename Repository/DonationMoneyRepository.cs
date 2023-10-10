using APPR6312POEPart1DAF.Data;
using APPR6312POEPart1DAF.Interfaces;
using APPR6312POEPart1DAF.Models;
using Microsoft.EntityFrameworkCore;

namespace APPR6312POEPart1DAF.Repository
{
    public class DonationMoneyRepository : IDonationMoneyRepository
    {
        private readonly ApplicationDbContext _context;

        public DonationMoneyRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public bool Add(DonationMoney donationMoney)
        {
            _context.Add(donationMoney);
            return Save();
        }

        public bool Delete(DonationMoney donationMoney)
        {
            _context.Remove(donationMoney);
            return Save();
        }

        public async Task<IEnumerable<DonationMoney>> GetAll()
        {
            return await _context.DonationsMoney.Include(i => i.Disaster).ToListAsync();
        }

        public async Task<DonationMoney> GetByIdAsync(int id)
        {
            return await _context.DonationsMoney.Include(i => i.Disaster).FirstOrDefaultAsync(i => i.DonationMoneyId == id);

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(DonationMoney donationMoney)
        {
            _context.Update(donationMoney);
            return Save();
        }
    }
}
