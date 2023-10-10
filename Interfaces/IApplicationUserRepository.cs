using APPR6312POEPart1DAF.Models;

namespace APPR6312POEPart1DAF.Interfaces
{
    public interface IApplicationUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAll();

        Task<ApplicationUser> GetByIdAsync(int id);

        Task<IEnumerable<ApplicationUser>> GetUserByUserName(string userName);

        bool Add(ApplicationUser applicationUser);
        bool Update(ApplicationUser applicationUser);
        bool Delete(ApplicationUser applicationUser);
        bool Save();
    }
}
