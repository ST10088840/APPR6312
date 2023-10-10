using APPR6312POEPart1DAF.Interfaces;
using APPR6312POEPart1DAF.Models;
using APPR6312POEPart1DAF.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APPR6312POEPart1DAF.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly IApplicationUserRepository _applicationUserRepository;

        public ApplicationUserController(IApplicationUserRepository userRepository)
        {
            _applicationUserRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<ApplicationUser> applicationUser = await _applicationUserRepository.GetAll();
            return View(applicationUser);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return View(applicationUser);
            }
            _applicationUserRepository.Add(applicationUser);
            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> Index(int id)
        //{
        //    ApplicationUser applicationUser = await _applicationUserRepository.GetByIdAsync(id);
        //    return View(applicationUser);
        //}
    }
}
