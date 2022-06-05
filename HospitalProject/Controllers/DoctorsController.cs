using Data.Entities;
using Data.HospitalCountext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly HospitalContext _context;
        public DoctorsController(HospitalContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            var hospitalContext = _context.Doctors.Include(r => r.Ward).Include(r=>r.User).Include(r=>r.Speciality);
            foreach (var item in hospitalContext)
            {

                item.Ward = _context.Wards.FirstOrDefault(t => t.Id == item.WardId);
                item.User = _context.Users.FirstOrDefault(t => t.Id == item.UserId);
            }
            return View(await hospitalContext.ToListAsync());
        }


        public ActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id","FirstName");
            ViewData["SpecialityId"] = new SelectList(_context.HospitalRoles, "Id", "Name");
            ViewData["WardId"] = new SelectList(_context.Wards, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Knowledge,UserId,SpecialityId,WardId,Id")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName",doctor.UserId);
            ViewData["SpecialityId"] = new SelectList(_context.HospitalRoles, "Id", "Name", doctor.SpecialityId);
            ViewData["WardId"] = new SelectList(_context.Wards, "Id", "Name", doctor.WardId);
            return View(doctor);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName",doctor.UserId);
            ViewData["SpecialityId"] = new SelectList(_context.HospitalRoles, "Id", "Name", doctor.SpecialityId);
            ViewData["WardId"] = new SelectList(_context.Wards, "Id", "Name", doctor.WardId);
            return View(doctor);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Knowledge,UserId,SpecialityId,WardId,Id")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", doctor.UserId);
            ViewData["SpecialityId"] = new SelectList(_context.HospitalRoles, "Id", "Name", doctor.SpecialityId);
            ViewData["WardId"] = new SelectList(_context.Wards, "Id", "Name", doctor.WardId);
            return View(doctor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(u => u.Ward)
                .Include(u=>u.User)
                .Include(u=>u.Speciality)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: DoctorsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
