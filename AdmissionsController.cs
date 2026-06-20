
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CityHospitalManagement.Models;

public class AdmissionsController : Controller
{
    private readonly HospitalContext _context;

    public AdmissionsController(HospitalContext context)
    {
        _context = context;
    }

    // GET: ADMISSIONS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Admissions.ToListAsync());
    }

    // GET: ADMISSIONS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var admission = await _context.Admissions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (admission == null)
        {
            return NotFound();
        }

        return View(admission);
    }

    // GET: ADMISSIONS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ADMISSIONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,PatientId,DoctorId,Ward,BedNo,AdmissionDate,DischargeDate")] Admission admission)
    {
        if (ModelState.IsValid)
        {
            _context.Add(admission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(admission);
    }

    // GET: ADMISSIONS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var admission = await _context.Admissions.FindAsync(id);
        if (admission == null)
        {
            return NotFound();
        }
        return View(admission);
    }

    // POST: ADMISSIONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,PatientId,DoctorId,Ward,BedNo,AdmissionDate,DischargeDate")] Admission admission)
    {
        if (id != admission.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(admission);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdmissionExists(admission.Id))
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
        return View(admission);
    }

    // GET: ADMISSIONS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var admission = await _context.Admissions
            .FirstOrDefaultAsync(m => m.Id == id);
        if (admission == null)
        {
            return NotFound();
        }

        return View(admission);
    }

    // POST: ADMISSIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var admission = await _context.Admissions.FindAsync(id);
        if (admission != null)
        {
            _context.Admissions.Remove(admission);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AdmissionExists(int? id)
    {
        return _context.Admissions.Any(e => e.Id == id);
    }
}
