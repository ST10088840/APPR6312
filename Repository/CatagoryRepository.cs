using APPR6312POEPart1DAF.Data;
using APPR6312POEPart1DAF.Interfaces;
using APPR6312POEPart1DAF.Models;
using Microsoft.EntityFrameworkCore;

namespace APPR6312POEPart1DAF.Repository
{
    public class CatagoryRepository : ICatagoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CatagoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Catagory catagory)
        {
            _context.Add(catagory);
            return Save();
        }

        public bool Delete(Catagory catagory)
        {
            _context.Remove(catagory);
            return Save();
        }

        public async Task<IEnumerable<Catagory>> GetAll()
        {
            return await _context.Catagories.ToListAsync();
        }

        public async Task<Catagory> GetByIdAsync(int id)
        {
            return await _context.Catagories.FirstOrDefaultAsync(i => i.CatagoryId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Catagory catagory)
        {
            _context.Update(catagory);
            return Save();
        }
    }
}
