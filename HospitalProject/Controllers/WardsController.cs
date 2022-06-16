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
        public async Task<IActionResult> Create(WardCreateViewModel wardCreateViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(wardCreateViewModel);
            }
            await this.wardService.CreateAsync(wardCreateViewModel);
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {

            var ward = await this.wardService.GetASS<WardCreateViewModel>(id);
            if (ward == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(context.Patients, "Id", "Name");
            return View(ward);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WardCreateViewModel wardCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await wardService.Update(wardCreateViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(wardCreateViewModel);
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
