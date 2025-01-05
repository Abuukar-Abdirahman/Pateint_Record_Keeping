using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestingPatient.Data;
using TestingPatient.Models;

namespace TestingPatient.Controllers
{
    [Authorize]
    public class PrescriptionController : Controller
    {
        private readonly PatientTestDb _context;

        public PrescriptionController(PatientTestDb context)
        {
            _context = context;
        }

        // GET: Prescription
        public async Task<IActionResult> Index()
        {
            var prescriptions = await _context.Prescriptions
                .Include(p => p.Appointment)
                .ThenInclude(a => a.Patient) // Assuming Appointment has a Patient navigation property
                .ToListAsync();
            return View(prescriptions);
        }

        // GET: Prescription/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions
                .Include(p => p.Appointment)
                .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // GET: Prescription/Create
        public IActionResult Create()
        {
            PopulateAppointmentsDropDownList();
            return View();
        }

        // POST: Prescription/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Medication,Dosage,Instructions,AppointmentId")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If model state is invalid, repopulate the Appointments list
            PopulateAppointmentsDropDownList(prescription.AppointmentId);
            return View(prescription);
        }

        // GET: Prescription/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }

            PopulateAppointmentsDropDownList(prescription.AppointmentId);
            return View(prescription);
        }

        // POST: Prescription/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Medication,Dosage,Instructions,AppointmentId")] Prescription prescription)
        {
            if (id != prescription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionExists(prescription.Id))
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

            // If model state is invalid, repopulate the Appointments list
            PopulateAppointmentsDropDownList(prescription.AppointmentId);
            return View(prescription);
        }

        // GET: Prescription/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions
                .Include(p => p.Appointment)
                .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // POST: Prescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription != null)
            {
                _context.Prescriptions.Remove(prescription);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionExists(int id)
        {
            return _context.Prescriptions.Any(e => e.Id == id);
        }

        // Helper method to populate Appointments dropdown
        private void PopulateAppointmentsDropDownList(object selectedAppointment = null)
        {
            var appointmentsQuery = _context.Appointments
                .Include(a => a.Patient) // To display patient name alongside appointment
                .OrderBy(a => a.AppointmentDate) // Assuming Appointment has a RecordDate or similar property
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = $"{a.AppointmentDate.ToString("MM/dd/yyyy")} - Patient: {a.Patient.Name}"
                })
                .ToList();

            ViewBag.AppointmentId = new SelectList(appointmentsQuery, "Value", "Text", selectedAppointment);
        }
    }
}
