using Data.Entities;
using Data.HospitalCountext;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service.DoctorService;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Controllers
{
    
    public class DoctorsController : Controller
    {
        private readonly HospitalContext _context;
        private readonly IDoctorService doctorService;
        public DoctorsController(HospitalContext context, IDoctorService doctorService)
        {
            _context = context;
            this.doctorService = doctorService;

        }
        public async Task<ActionResult> Index()
        {
            var doctors = await doctorService.GetAsync<DoctorViewModel>();            
            return View( doctors);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id","FirstName");
            ViewData["SpecialityId"] = new SelectList(_context.HospitalRoles, "Id", "Name");
            ViewData["WardId"] = new SelectList(_context.Wards, "Id", "Name");

            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorCreateViewModel doctorCreateViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(doctorCreateViewModel);
            }
            await this.doctorService.CreateAsync(doctorCreateViewModel);
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await this.doctorService.GetASS<DoctorCreateViewModel>(id);
            if (doctor == null)
            {
                return NotFound();
            }
            
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName",doctor.UserId);
            ViewData["SpecialityId"] = new SelectList(_context.HospitalRoles, "Id", "Name", doctor.SpecialityId);
            ViewData["WardId"] = new SelectList(_context.Wards, "Id", "Name", doctor.WardId);
            return View(doctor);
            
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorCreateViewModel doctorCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await doctorService.Update(doctorCreateViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(doctorCreateViewModel);
        }
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await doctorService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
