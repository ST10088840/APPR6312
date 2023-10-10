using APPR6312POEPart1DAF.Data;
using APPR6312POEPart1DAF.Interfaces;
using APPR6312POEPart1DAF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APPR6312POEPart1DAF.Repository
{
    public class DonationItemRepository : IDonationItemRepository
    {
        private readonly ApplicationDbContext _context;
        public DonationItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(DonationItem donationItem)
        {
            _context.Add(donationItem);
            return Save();
        }

        public bool Delete(DonationItem donationItem)
        {
            _context.Remove(donationItem);
            return Save();
        }

        public async Task<IEnumerable<DonationItem>> GetAll()
        {
            return await _context.DonationsItems.Include(i => i.Catagory).Include(i => i.Disaster).ToListAsync();
        }//'t => ((Derived)t).MyProperty'

        public async Task<IEnumerable<DonationItem>> GetAllDonationItemsByCatagory(string catagory)
        {
            return await _context.DonationsItems.Where(c => c.Catagory.CatagoryName.Contains(catagory)).ToListAsync();
        }

        public async Task<DonationItem> GetByIdAsync(int id)
        {
            return await _context.DonationsItems.Include(i => i.CatagoryID).FirstOrDefaultAsync(i => i.ItemDonationId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(DonationItem donationItem)
        {
            _context.Update(donationItem);
            return Save();
        }
    }
}
