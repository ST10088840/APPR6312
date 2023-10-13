using APPR6312POEPart1DAF.Data;
using APPR6312POEPart1DAF.Interfaces;
using APPR6312POEPart1DAF.Models;
using APPR6312POEPart1DAF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace APPR6312POEPart1DAF.Controllers
{
    public class DonationItemController : Controller
    {
        //private readonly ApplicationDbContext? _context;
        private readonly IDonationItemRepository _donationItemRepository;

        public DonationItemController(IDonationItemRepository donationItemRepository)           
        {
            _donationItemRepository = donationItemRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<DonationItem> donationsItems = await _donationItemRepository.GetAll();
            return View(donationsItems);
        }

        public async Task<IActionResult> Details(int id) 
        {
            DonationItem donationItem = await _donationItemRepository.GetByIdAsync(id);
            //DonationItem donationItem2 = await _context.Include(a => a.Catagory).FirstOrDefault(c => c.Id == id);
            return View(donationItem);
        }

        public IActionResult Create()
        {
            //var categories = await _context.Catagories.ToListAsync();

            // ViewData["Categories"] = new SelectList(categories, "CategoryId", "CategoryName");

            return View();
        }

        public IActionResult MoneyToItems()
        {
            // Retrieve the value of the temporary estimated cost input
            var model = new DonationItem();
            var temporaryEstimatedCost = Request.Form["TemporaryEstimatedCost"];

            // Parse the value to a numeric type if needed
            if (decimal.TryParse(temporaryEstimatedCost, out var estimatedCostValue))
            {
                // Check the estimated cost against a certain limit
                if (estimatedCostValue > 13000)
                {
                    // Handle the case where the estimated cost exceeds the limit
                    ModelState.AddModelError("TemporaryEstimatedCost", "Estimated cost exceeds the limit.");
                }
            }

            // Check other model properties, validate, and save to the database
            if (ModelState.IsValid)
            {
                // Your logic to save the model to the database
                return RedirectToAction("Create");
            }

            // If there are validation errors, return the view with error messages
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(DonationItem donationItem)
        {
            if (!ModelState.IsValid)
            {
                return View(donationItem);
            }
            _donationItemRepository.Add(donationItem);
            return RedirectToAction("Index");
        }
    }
}
