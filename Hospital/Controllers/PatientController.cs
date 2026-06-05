using System.Diagnostics;
using Hospital.Data;
using Hospital.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    [Authorize] //All hospital staff have access
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext context;
        public PatientController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //All staff has access to the overview
        public async Task<IActionResult> Index()
        {
            var patients = await context.Patients.ToListAsync();
            return View(patients);
        }

        //All staff has access to the details of the patient

        public async Task<IActionResult> Details (int id)
        {
            var patient = await context.Patients.FindAsync(id);
            if(patient == null)
                return NotFound();
            else 
                return View(patient);
        }

        //Add a patiënt - Only by nurse

        [Authorize(Roles ="Nurse")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Nurse")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Patient patient)
        {
            if(ModelState.IsValid)
            {
                context.Patients.Add(patient);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
            
        }
        //Edit patient info - Only by nurse

        [Authorize(Roles = "Nurse")]
        public async Task<IActionResult> Edit(int id)
        {
            var patient = await context.Patients.FindAsync(id);
            if(patient == null)
                return NotFound();
            else
                return View(patient);
        }
        [HttpPost]
        [Authorize(Roles = "Nurse")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Patient patient,int id)
        {
            if (ModelState.IsValid)
            {
                context.Patients.Update(patient);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        //Discharge patient - only by nurse
        [Authorize(Roles = "Nurse")]
        public async Task<IActionResult> Discharge(int id)
        {
            var patient = await context.Patients.FindAsync(id);
            if (patient == null)
                return NotFound();
            else
                return View(patient);
        }
        [HttpPost, ActionName("Discharge")]
        [Authorize(Roles = "Nurse")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DischargeConfirmed(int id)
        {
            var patient = await context.Patients.FindAsync(id);
            if(patient != null)
            { 
                //save information of patient in history
                var history = new AdmissionHistory
                {
                    OriginalPatientId = patient.Id,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Birthdate = patient.Birthdate,
                    Diagnosis = patient.Diagnosis,
                    Gender = patient.Gender,
                    Address = patient.Address,
                    PhoneNumber = patient.PhoneNumber,
                    RegistrationDate = patient.RegistrationDate,
                    RoomNumber = patient.RoomNumber,
                    RoomType = patient.RoomType,
                    Allergies = patient.Allergies,
                    DischargedOn = DateTime.Now
                };
                context.AdmissionHistories.Add(history);
                context.Patients.Remove(patient);
                await context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        //All staff but kitchen staff has access to the admission history
        [Authorize(Roles = "Doctor, Nurse, Psychologist")]
        
        public async Task<IActionResult> AdmissionHistory()
        {
            var history = await context.AdmissionHistories
                .OrderByDescending(h => h.DischargedOn)
                .ToListAsync();
            return View(history);
        }
        

    }
}
