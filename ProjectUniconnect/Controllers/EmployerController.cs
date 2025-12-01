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
            _context = context;
        }

        // ========= LIST + SEARCH =========
        public async Task<IActionResult> Index(string search)
        {
            var query = _context.Employers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                // (Search) 
                query = query.Where(e =>
                    e.CompanyName.Contains(search) ||
                    e.Email.Contains(search));
            }

            var list = await query
                .OrderBy(e => e.CompanyName)
                .ToListAsync();

            ViewBag.Search = search;
            return View(list);
        }

        // ========= SIGNUP = CREATE =========
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(Employer model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // (Insert)
            _context.Employers.Add(model);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Employer registered successfully.";
            return RedirectToAction(nameof(Index));
        }

        // ========= EDIT = UPDATE =========
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employer = await _context.Employers.FindAsync(id);
            if (employer == null) return NotFound();
            return View(employer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employer model)
        {
            if (id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);

            // (Update) 
            _context.Update(model);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ========= DELETE =========
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var employer = await _context.Employers
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employer == null) return NotFound();
            return View(employer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employer = await _context.Employers.FindAsync(id);
            if (employer == null) return NotFound();

            // (Delete) 
            _context.Employers.Remove(employer);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // ========= LOGIN GET =========
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
