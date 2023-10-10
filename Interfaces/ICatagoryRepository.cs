using APPR6312POEPart1DAF.Models;

namespace APPR6312POEPart1DAF.Interfaces
{
    public interface ICatagoryRepository
    {
        Task<IEnumerable<Catagory>> GetAll();

        Task<Catagory> GetByIdAsync(int id);

        bool Add(Catagory catagory);
        bool Update(Catagory catagory);
        bool Delete(Catagory catagory);
        bool Save();
    }
}
