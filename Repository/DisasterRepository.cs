using APPR6312POEPart1DAF.Data;
using APPR6312POEPart1DAF.Interfaces;
using APPR6312POEPart1DAF.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace APPR6312POEPart1DAF.Repository
{
    public class DisasterRepository : IDisasterRepository
    {
        private readonly ApplicationDbContext _context;
        public DisasterRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Disaster disaster)
        {
            _context.Add(disaster);
            return Save();
        }

        public bool Delete(Disaster disaster)
        {
            _context.Remove(disaster);
            return Save();
        }

        public async Task<IEnumerable<Disaster>> GetAll()
        {
            return await _context.Disasters.ToListAsync();
        }

        //public async Task<IEnumerable<DonationItem>> GetAllDisasterByCatagory(string catagory) //special method to get all disasters with a shared catagory
        //{
        //    return await _context.DonationsItems.Where(c => c.Catagory.CatagoryName.Contains(catagory)).ToListAsync();
        //}

        public async Task<IEnumerable<DonationItem>> GetAllDisasterByLocation(string location) //special method to get all disasters with a shared location
        {
            return (IEnumerable<DonationItem>)await _context.Disasters.FirstOrDefaultAsync(i => i.Location == location);
            
        }

        public async Task<Disaster> GetByIdAsync(int id)
        {
            var disaster =  await _context.Disasters
                .Include(d => d.DonationsMoney)
                .Include(d => d.DonationsItems)
                .FirstOrDefaultAsync(d => d.DisasterId == id);
            if (disaster == null)
            {
                //tbd
            }
            return disaster;
        }


        public bool Save()
        {
            //return Save();   returns 0 or 1
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;      // now returns true or false
        }

        public bool Update(Disaster disaster)
        {
            _context.Update(disaster);
            return Save();
        }

    }
}
