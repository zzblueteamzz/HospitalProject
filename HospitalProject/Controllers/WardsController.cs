using Data.Entities;
using Data.HospitalCountext;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service.WardService;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Controllers
{
    public class WardsController : Controller
    {
         private readonly HospitalContext context;
        private readonly IWardService wardService;

        public WardsController(HospitalContext context, IWardService wardService)
        {
            this.context= context;
            this.wardService = wardService;
        }
        public async Task<ActionResult> Index()
        {
            var ward = await wardService.GetAsync<WardViewModel>();

            return View(ward);
        }
        [Authorize]
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(context.Patients, "Id", "Name");
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,PatientId,Id")] Ward ward)
        {
            if (ModelState.IsValid)
            {
                context.Add(ward);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(context.Patients, "Id", "Name", ward.PatientId);
            return View(ward);
        }
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ward = await context.Wards.FindAsync(id);
            if (ward == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(context.Patients, "Id", "Name", ward.PatientId);
            return View(ward);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,PatientId,Id")] Ward ward)
        {
            if (id != ward.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(ward);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WardExists(ward.Id))
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
            ViewData["PatientId"] = new SelectList(context.Patients, "Id", "Name", ward.PatientId);
            return View(ward);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await wardService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        private bool WardExists(int id)
        {
            return context.Wards.Any(e => e.Id == id);
        }
    }
}
