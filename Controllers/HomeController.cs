using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        BbdbContext bd=new BbdbContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<BloodDonor> donors = bd.BloodDonors.ToList();
            return View(donors);
        }        
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult WhyNeedBlood()
        {
            return View();
        }
        public IActionResult NeedBlood()
        {
            ViewBag.HospitalList = bd.Hospitals.ToList();
            return View();
        }
        public IActionResult TakeBlood(int donorId)
        {
            var donor = bd.BloodDonors.Find(donorId);

            // Check if the donor is found5
            if (donor != null)
            {
                // Perform the logic to "take blood" (e.g., update database, remove donor, etc.)
                bd.BloodDonors.Remove(donor);
                var Nurse = bd.NurseStaffs.FirstOrDefault(bd => bd.NurseId == donor.NurseId);
                if (Nurse != null)
                {
                    var hos = bd.MainHospitals.FirstOrDefault(bd => bd.HospId == Nurse.HospitalId);
                    if (hos != null)
                    {
                        hos.Quantity--;
                    }
                }
                bd.SaveChanges();
            }
            // Redirect back to the search result view or any other appropriate page
            return RedirectToAction("Index");

        }
        public IActionResult SearchResult()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NeedBlood(NeedBlood needBlood)
        {
            var blood =bd.BloodGroups.FirstOrDefault(bd=>bd.BloodGroup1==needBlood.BloodGroup);
            var group = bd.DonorBloodComp.Where(dbc => dbc.BloodId == blood.BloodId).Select(dbc => dbc.BloodGroup1).ToList();

            var results = bd.BloodDonors.Where(donor => group.Contains(donor.BdGroup)).ToList();
            var hos = bd.Hospitals.FirstOrDefault(bd => bd.HospitalNeededBlood == needBlood.HospitalId);
            if (hos != null)
            {
               // Increment the HospitalNeededBlood property
                hos.HospNeededQnty++;
               // Save changes to the database
                bd.SaveChanges();
            }
            // Pass the results and needBlood to the view
            ViewData["SearchResults"] = results;
            bd.NeedBloods.Add(needBlood);
            bd.SaveChanges();
            // Redirect to the SearchResult view
            return View("SearchResult");
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public IActionResult BecomeDonor()
        {
            ViewBag.Nurses = bd.NurseStaffs.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult BecomeDonor(BloodDonor bloodDonor)
        {
            var Nurse = bd.NurseStaffs.FirstOrDefault(bd => bd.NurseId == bloodDonor.NurseId);
            if (Nurse != null)
            {
                var hos = bd.MainHospitals.FirstOrDefault(bd => bd.HospId == Nurse.HospitalId);
                if (hos!= null)
                {
                    hos.Quantity++;
                }
            }

            bd.BloodDonors.Add(bloodDonor);
                bd.SaveChanges();
                return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
