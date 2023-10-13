using APPR6312POEPart1DAF.Data;
using APPR6312POEPart1DAF.Interfaces;
using APPR6312POEPart1DAF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APPR6312POEPart1DAF.Repository;
using APPR6312POEPart1DAF.ViewModels;

namespace APPR6312POEPart1DAF.Controllers
{
    public class DisasterController : Controller
    {
        private readonly IDisasterRepository _disasterRepository;

        public DisasterController(IDisasterRepository disasterRepository)
        {
            _disasterRepository = disasterRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Disaster> disaster = await _disasterRepository.GetAll();
            return View(disaster);
        }

        public async Task<IActionResult> Details(int id)
        {
            Disaster disaster = await _disasterRepository.GetByIdAsync(id);
            return View(disaster);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Summary(int id)
        {
            // Retrieve the disaster and related data
            if (id == null)
            {
                id = 2;
            }
            var disaster = await _disasterRepository.GetByIdAsync(id);

            if (disaster == null)
            {
                return NotFound();
            }

            return View(disaster);
        }


        [HttpPost]
        public IActionResult Create(Disaster disaster)
        {
            if (!ModelState.IsValid)
            {
                return View(disaster);
            }
            _disasterRepository.Add(disaster);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var disaster = await _disasterRepository.GetByIdAsync(id);
            if (disaster == null) return View("Error");
            var disasterVM = new EditDisasterViewModel
            {
                Title = disaster.Title,
                Location = disaster.Location,
                Description = disaster.Description,
                StartDate = disaster.StartDate,
                EndDate = disaster.EndDate
            };
            return View(disasterVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditDisasterViewModel disasterVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit disastser");
                return View("Edit", disasterVM);
            }

            var userDisaster = await _disasterRepository.GetByIdAsync(id);

            if (userDisaster != null)
            {

            }
            return View("Edit", disasterVM);
        }

        //public async Task<IActionResult> DisasterDetails(int id)
        //{
        //    // Fetch the disaster by ID
        //    var disaster = await _disasterRepository.GetByIdAsync(id)

        //    _disasterRepository.Entry(disaster).Collection(d => d.DonationMonies).Load();
        //    _disasterRepository.Entry(disaster).Collection(d => d.DonationItems).Load();
        //        .Include(d => d.DonationMonies)
        //        .Include(d => d.DonationItems)
        //        .FirstOrDefault(d => d.DisasterId == id);

        //    if (disaster == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(disaster);
        //}

    }
}
