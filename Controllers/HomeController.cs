using AreEyeP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;

namespace AreEyeP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Home/Dashboard
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

        // GET: /Home/BurialApplication
        [HttpGet]
        public IActionResult BurialApplication()
        {
            return View();
        }

        // POST: /Home/SubmitBurialApplication
        [HttpPost]
        public IActionResult SubmitBurialApplication(BurialApplicationViewModel model)
        {
            if (model.AttachedRequirement == null || model.AttachedRequirement.Length == 0)
            {
                ModelState.AddModelError("AttachedRequirement", "The Attach Requirement field is required.");
            }

            if (ModelState.IsValid)
            {
                string filePath = null;

                // Handle file upload
                if (model.AttachedRequirement != null && model.AttachedRequirement.Length > 0)
                {
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    Directory.CreateDirectory(uploads); // Ensure the directory exists

                    // Generate a unique filename to avoid conflicts
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.AttachedRequirement.FileName);
                    filePath = Path.Combine(uploads, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.AttachedRequirement.CopyTo(fileStream);
                    }
                }

                var burialApplication = new BurialApplication
                {
                    ApplicantFirstName = model.ApplicantFirstName,
                    ApplicantLastName = model.ApplicantLastName,
                    Address = model.Address,
                    RelationshipToDeceased = model.RelationshipToDeceased,
                    ContactInformation = model.ContactInformation,
                    DeceasedFirstName = model.DeceasedFirstName,
                    DeceasedLastName = model.DeceasedLastName,
                    DeceasedGender = model.DeceasedGender,
                    DeceasedDateOfBirth = model.DeceasedDateOfBirth,
                    DeceasedDateOfDeath = model.DeceasedDateOfDeath,
                    CauseOfDeath = model.CauseOfDeath,
                    Religion = model.Religion,
                    BurialDate = model.BurialDate,
                    BurialStartTime = model.BurialStartTime,
                    BurialEndTime = model.BurialEndTime,
                    SpecialInstructions = model.SpecialInstructions,
                    AttachedRequirement = filePath // Save the file path to the database
                };

                _context.BurialApplications.Add(burialApplication);
                _context.SaveChanges();

                return RedirectToAction("Dashboard");
            }

            return View("BurialApplication", model);
        }
    }
}
