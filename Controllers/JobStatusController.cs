using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPFinal.Models;
using careerPortals.Data;

namespace ASPFinal.Controllers
{
    public class JobStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobStatus.ToListAsync());
        }

        // GET: JobStatus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobStatus = await _context.JobStatus
                .FirstOrDefaultAsync(m => m.Name == id);
            if (jobStatus == null)
            {
                return NotFound();
            }

            return View(jobStatus);
        }

        // GET: JobStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] JobStatus jobStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobStatus);
        }

        // GET: JobStatus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobStatus = await _context.JobStatus.FindAsync(id);
            if (jobStatus == null)
            {
                return NotFound();
            }
            return View(jobStatus);
        }

        // POST: JobStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name")] JobStatus jobStatus)
        {
            if (id != jobStatus.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobStatusExists(jobStatus.Name))
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
            return View(jobStatus);
        }

        // GET: JobStatus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobStatus = await _context.JobStatus
                .FirstOrDefaultAsync(m => m.Name == id);
            if (jobStatus == null)
            {
                return NotFound();
            }

            return View(jobStatus);
        }

        // POST: JobStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var jobStatus = await _context.JobStatus.FindAsync(id);
            _context.JobStatus.Remove(jobStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobStatusExists(string id)
        {
            return _context.JobStatus.Any(e => e.Name == id);
        }
    }
}
