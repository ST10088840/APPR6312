using APPR6312POEPart1DAF.Models;

namespace APPR6312POEPart1DAF.Interfaces
{
    public interface IDonationMoneyRepository
    {
        Task<IEnumerable<DonationMoney>> GetAll();

        Task<DonationMoney> GetByIdAsync(int id);

        //Task<IEnumerable<DonationMoney>> GetAllDonationMoneyByString(string something);

        bool Add(DonationMoney donationItem);
        bool Update(DonationMoney donationItem);
        bool Delete(DonationMoney donationItem);
        bool Save();
    }
}
