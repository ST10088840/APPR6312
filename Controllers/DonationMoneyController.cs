using APPR6312POEPart1DAF.Data;
using Microsoft.AspNetCore.Mvc;
using APPR6312POEPart1DAF.Interfaces;
using APPR6312POEPart1DAF.Models;
using APPR6312POEPart1DAF.Repository;

namespace APPR6312POEPart1DAF.Controllers
{
    public class DonationMoneyController : Controller
    {
        private readonly IDonationMoneyRepository _donationMoneyRepository; 
        public DonationMoneyController(IDonationMoneyRepository donationMoneyRepository)
        {
            _donationMoneyRepository = donationMoneyRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<DonationMoney> donationsMoney = await _donationMoneyRepository.GetAll();
            return View(donationsMoney);
        }

        public async Task<IActionResult> Details(int id)
        {
            DonationMoney donationMoney = await _donationMoneyRepository.GetByIdAsync(id);
            return View(donationMoney);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DonationMoney donationMoney)
        {
            if (!ModelState.IsValid)
            {
                return View(donationMoney);
            }
            _donationMoneyRepository.Add(donationMoney);
            return RedirectToAction("Index");
        }
    }
}
