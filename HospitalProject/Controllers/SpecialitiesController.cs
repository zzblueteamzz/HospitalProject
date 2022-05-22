using Data.Entities;
using Data.HospitalCountext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Controllers
{
    public class SpecialitiesController : Controller
    {
           private readonly HospitalContext _context;
            public SpecialitiesController(HospitalContext context)
            {
                _context = context;
            }

            // GET: Roles
            public async Task<IActionResult> Index()
            {
               // ViewBag.UserRole = UserCredentialsHelper.FindUserRole(_context, User);
                return View(await _context.Specialities.ToListAsync());
            }

            // GET: Roles/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var speciality = await _context.Specialities
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (speciality == null)
                {
                    return NotFound();
                }

                return View(speciality);
            }

            // GET: Roles/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Roles/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Name,Id")] Speciality speciality)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(speciality);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(speciality);
            }

            // GET: Roles/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var speciality = await _context.Specialities.FindAsync(id);
                if (speciality == null)
                {
                    return NotFound();
                }
                return View(speciality);
            }

            // POST: Roles/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] Speciality speciality)
            {
                if (id != speciality.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(speciality);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SpecialitiesExists(speciality.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(speciality);
            }

            // GET: Roles/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var speciality = await _context.Specialities
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (speciality == null)
                {
                    return NotFound();
                }

                return View(speciality);
            }

            // POST: Roles/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var speciality = await _context.Specialities.FindAsync(id);
                _context.Specialities.Remove(speciality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool SpecialitiesExists(int id)
            {
                return _context.Specialities.Any(e => e.Id == id);
            }
        }
}
