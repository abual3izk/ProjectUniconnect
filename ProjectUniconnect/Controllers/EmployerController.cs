using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectUniconnect.Data;
using ProjectUniconnect.Models;

namespace ProjectUniconnect.Controllers
{
    public class EmployerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployerController(ApplicationDbContext context)
        {
            _context = context; // DB context
        }

        // ========= LIST + SEARCH =========
        public async Task<IActionResult> Index(string search)
        {
            var query = _context.Employers.AsQueryable(); // Base query

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Search by company name OR email
                query = query.Where(e =>
                    e.CompanyName.Contains(search) ||
                    e.Email.Contains(search));
            }

            // Get list ordered by company name
            var list = await query
                .OrderBy(e => e.CompanyName)
                .ToListAsync();

            ViewBag.Search = search; // Keep search value
            return View(list);       // Return list to view
        }

        // ========= SIGNUP = CREATE =========
        [HttpGet]
        public IActionResult Signup()
        {
            return View(); // Show signup form
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(Employer model)
        {
            if (!ModelState.IsValid)
                return View(model); // Validation failed

            // Insert new employer
            _context.Employers.Add(model);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Employer registered successfully."; // Success message
            return RedirectToAction(nameof(Index));
        }

        // ========= EDIT = UPDATE =========
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employer = await _context.Employers.FindAsync(id);
            if (employer == null) return NotFound(); // Not found

            return View(employer); // Load edit page
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employer model)
        {
            if (id != model.Id) return BadRequest();   // ID mismatch
            if (!ModelState.IsValid) return View(model);

            // Update employer
            _context.Update(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); // Back to list
        }

        // ========= DELETE =========
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var employer = await _context.Employers
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employer == null) return NotFound();
            return View(employer); // Show delete confirmation
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employer = await _context.Employers.FindAsync(id);
            if (employer == null) return NotFound();

            // Delete employer
            _context.Employers.Remove(employer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ========= LOGIN =========
        [HttpGet]
        public IActionResult Login()
        {
            return View(); // Show login form
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Check login credentials
            var employer = _context.Employers
                .FirstOrDefault(e => e.Email == email && e.Password == password);

            if (employer == null)
            {
                ViewBag.Error = "Invalid login"; // Wrong email/password
                return View();
            }

            // Save session values
            HttpContext.Session.SetString("EmployerName", employer.CompanyName);
            HttpContext.Session.SetInt32("EmployerId", employer.Id);

            return RedirectToAction("Index", "Home"); // Redirect after login
        }
    }
}
