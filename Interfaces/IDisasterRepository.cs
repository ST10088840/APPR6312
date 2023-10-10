using APPR6312POEPart1DAF.Models;

namespace APPR6312POEPart1DAF.Interfaces
{
    public interface IDisasterRepository
    {
        Task<IEnumerable<Disaster>> GetAll();

        Task<Disaster> GetByIdAsync(int id);

        Task<IEnumerable<DonationItem>> GetAllDisasterByLocation(string location);

        //Task<IEnumerable<DonationItem>> GetAllDisasterByCatagory(string catagory);

        bool Add(Disaster disaster);
        bool Update(Disaster disaster); 
        bool Delete(Disaster disaster);
        bool Save();
    }
}
