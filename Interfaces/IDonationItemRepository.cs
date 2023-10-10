using APPR6312POEPart1DAF.Models;

namespace APPR6312POEPart1DAF.Interfaces
{
    public interface IDonationItemRepository
    {
        Task<IEnumerable<DonationItem>> GetAll();

        Task<DonationItem> GetByIdAsync(int id);

        Task<IEnumerable<DonationItem>> GetAllDonationItemsByCatagory(string catagory);

        bool Add(DonationItem donationItem);
        bool Update(DonationItem donationItem);
        bool Delete(DonationItem donationItem);
        bool Save();
    }
}
