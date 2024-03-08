using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BbManagerController : Controller
    {
        BbdbContext dbbContext=new BbdbContext();
        public IActionResult Index()
        {
            int donorCount = dbbContext.BloodDonors.Count();
            int NeedbloodCount = dbbContext.NeedBloods.Count();

            ViewBag.DonorCount = donorCount;
            ViewBag.NeedBloodCount = NeedbloodCount;
            return View();
        }
            public IActionResult AddNurse()
            {
                ViewBag.HospitalList = dbbContext.MainHospitals.ToList();
                return View();
            }
        [HttpPost]
        public IActionResult AddNurse(NurseStaff nurseStaff)
        {
            dbbContext.NurseStaffs.Add(nurseStaff);
            dbbContext.SaveChanges();
            return RedirectToAction("Index");
        }       
        public IActionResult AddHos()
        {
            ViewBag.HospitalList = dbbContext.MainHospitals.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddHos(Hospital hos)
        {
            dbbContext.Hospitals.Add(hos);
            dbbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult AddDonor()
        {
            ViewBag.Nurses = dbbContext.NurseStaffs.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddDonor(BloodDonor? BB)
        {
            var Nurse = dbbContext.NurseStaffs.FirstOrDefault(bd => bd.NurseId == BB.NurseId);
            if (Nurse != null)
            {
                var hos = dbbContext.MainHospitals.FirstOrDefault(bd => bd.HospId == Nurse.HospitalId);
                if (hos != null)
                {
                    hos.Quantity++;
                }
            }
            dbbContext.BloodDonors.Add(BB);
            dbbContext.SaveChanges();
            return RedirectToAction("DonorList");
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        public IActionResult AddHospital()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHospital(MainHospital mh)
        {
            
                dbbContext.MainHospitals.Add(mh);
                dbbContext.SaveChanges();
                return RedirectToAction("DonorList");

        }
        public IActionResult HospitalList()
        {
            // Assuming that bd is your database context
            var hospitals = dbbContext.MainHospitals.ToList();

            return View(hospitals);
        }


        public IActionResult DonorList()
        {
            List<BloodDonor> donors = dbbContext.BloodDonors.ToList();
            return View(donors);
        }
        public IActionResult NeedBloodList()
        {
            List<NeedBlood> needBloods = dbbContext.NeedBloods.ToList();
            return View(needBloods);
        }
        public IActionResult Query()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [AllowAnonymous]

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult SignIn(BbManager? bb)
        {
            if (ModelState.IsValid)
            {
                string username = bb.MUserName;
                string password = bb.Password;
                // Your sign-in logic
                var manager = BbManager.GetManager(username, password);
                if (manager != null)
                {
                    if (manager.IsAdmin)
                    // Successful sign-in
                    // Redirect to a dashboard or home page
                    return RedirectToAction("Index", "BbManager");
                    else
                    {  
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    // Failed sign-in
                    // Add an error message and return to the sign-in page
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    return View("SignIn");
                }
            }
            else
            {
                return View("Error");
            }
        }
    }
}

