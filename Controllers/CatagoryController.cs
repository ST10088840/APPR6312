using APPR6312POEPart1DAF.Interfaces;
using APPR6312POEPart1DAF.Models;
using APPR6312POEPart1DAF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APPR6312POEPart1DAF.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly ICatagoryRepository _catagoryRepository;

        public CatagoryController(ICatagoryRepository catagoryRepository)
        {
            _catagoryRepository = catagoryRepository;
        }
        
        public async Task<IActionResult> Index()
        {
            IEnumerable<Catagory> catagory = await _catagoryRepository.GetAll(); 
            return View(catagory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Catagory catagory)
        {
            if (!ModelState.IsValid)
            {
                return View(catagory);
            }
            _catagoryRepository.Add(catagory);
            return RedirectToAction("Index");
        }
    }
}
