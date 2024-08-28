using AreEyeP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Linq;

namespace AreEyeP.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the username or email already exists
                if (_context.Users.Any(u => u.Username == model.Username || u.Email == model.Email))
                {
                    ModelState.AddModelError(string.Empty, "Username or Email is already taken.");
                    return View(model);
                }

                // Hash the password before storing it
                var hashedPassword = HashPassword(model.Password);

                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Day = model.Day,
                    Month = model.Month,
                    Year = model.Year,
                    Gender = model.Gender,
                    ContactNumber = model.ContactNumber,
                    Email = model.Email,
                    Username = model.Username,
                    Password = hashedPassword // Store the hashed password
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                // Redirect to the login page after successful registration
                return RedirectToAction("Login", "Account");
            }

            // If the model is not valid, return the view with the current model data to show validation errors
            return View(model);
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.SingleOrDefault(u => u.Username == model.Username);

                if (user != null && VerifyPassword(user.Password, model.Password))
                {
                    // User is authenticated
                    // Set session variables
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetInt32("UserId", user.Id);

                    // Redirect to the Dashboard page
                    return RedirectToAction("Dashboard", "Home");
                }

                // Invalid login attempt
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            return View(model);
        }

        // GET: /Account/Logout
        [HttpGet]
        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Redirect to the login page
            return RedirectToAction("Login", "Account");
        }

        // Utility method for hashing passwords
        private string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}:{hashed}";
        }

        // Utility method for verifying hashed passwords
        private bool VerifyPassword(string storedPassword, string enteredPassword)
        {
            var parts = storedPassword.Split(':');
            var salt = Convert.FromBase64String(parts[0]);
            var storedHash = parts[1];

            string enteredHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return storedHash == enteredHash;
        }
    }
}
