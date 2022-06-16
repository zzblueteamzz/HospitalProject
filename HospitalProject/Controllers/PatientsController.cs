using Data.Entities;
using Data.HospitalCountext;
using Data.ViewModels;
using HospitalProject.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.PatientService;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalProject.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientService patientService;
        private readonly IPatientPaginatingService patientPaginatingService;
        public PatientsController(IPatientService patientService, IPatientPaginatingService patientPaginatingService)
        {
            this.patientService = patientService;
            this.patientPaginatingService = patientPaginatingService;
        }
        [Authorize]
        public async Task<IActionResult> Index(string sortOrder,string currentFilter, string searchString,int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            int pageSize = 5;
            var model = await patientPaginatingService.GetPageAsync(searchString, pageNumber??1, pageSize);
            return View(model);
        
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientViewModel patientViewModel)
        {
        
            if (!ModelState.IsValid)
            {
                return View(patientViewModel);
            }
           await this.patientService.CreateAsync(patientViewModel);
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {

            var patient = await this.patientService.GetAsync<PatientViewModel>(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientViewModel patientViewModel)
        {
            if (ModelState.IsValid)
            {
                await patientService.Update(patientViewModel);
                
                return RedirectToAction(nameof(Index));
            }
            return View(patientViewModel);
        }
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await patientService.Delete(id);
            return RedirectToAction(nameof(Index)); 
        }

    }
}
